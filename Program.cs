using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GoalTracker.Data;
using GoalTracker.Models;
using Microsoft.AspNetCore.Identity;
using GoalTracker.Areas.Identity.Data;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.WebUtilities;
using System.Configuration;
using GoalTracker.Utils;
using Microsoft.Extensions.ObjectPool;
using GoalTracker.RabbitMQ;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using GoalTracker.Hubs;
using Microsoft.AspNetCore.SignalR;
using GoalTracker.Enums;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<GoalTrackerContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("GoalTrackerContextDev")
            ?? throw new InvalidOperationException("Connection string 'GoalTrackerContextDev' not found.")));
}
else
{
    builder.Services.AddDbContext<GoalTrackerContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("GoalTrackerContextProd")
            ?? throw new InvalidOperationException("Connection string 'GoalTrackerContextProd' not found.")));
}

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(
    options => options.SignIn.RequireConfirmedAccount = true
    ).AddEntityFrameworkStores<GoalTrackerContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IMessageProducer, RabbitMQProducer>();
builder.Services.AddSignalR();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);

    var roleManager = services.GetRequiredService<RoleManager<ApplicationRole>>();
    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

    string[] adminRoles = { "Admin", "ConfirmedAccount" };
    string[] testUserRoles = { "ConfirmedAccount" };

    foreach (var role in adminRoles)
    {
        var roleExists = await roleManager.RoleExistsAsync(role);
        if (!roleExists)
        {
            await roleManager.CreateAsync(new ApplicationRole() { Name = role });
        }
    }

    await Utils.SetUpDefaultUser(builder, userManager, "AdminUser", adminRoles);
    await Utils.SetUpDefaultUser(builder, userManager, "TestUser", testUserRoles);
}



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.MapHub<NotificationHub>("/NotificationsHub");
app.MapHub<OnlinePresenceIndicatorHub>("/OnlinePresenceIndications");



app.Use(async (context, next) =>
{
    var userManager = context.RequestServices.GetRequiredService<UserManager<ApplicationUser>>();
    var user = userManager.GetUserAsync(context.User).Result;
    var _hubContext = context.RequestServices.GetRequiredService<IHubContext<NotificationHub>>();

    if (user is not null)
    {
        user.OnlinePresenceIndicator = DateTime.Now;
        await userManager.UpdateAsync(user);
    }

    var factory = new ConnectionFactory
    {
        HostName = "localhost",
        DispatchConsumersAsync = false,
        ConsumerDispatchConcurrency = 1,
    };
    using var connection = factory.CreateConnection();
    using var channel = connection.CreateModel();

    channel.QueueDeclare("ApplicationNotifications",
            durable: false,
            exclusive: false,
            autoDelete: true,
            arguments: null);

    var consumer = new EventingBasicConsumer(channel);
    consumer.Received += async (model, eventArgs) =>
    {
        var body = eventArgs.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);
        channel.BasicAck(eventArgs.DeliveryTag, false);
        await _hubContext!.Clients.All.SendAsync("ReceiveMessage", message);
    };
    channel.BasicConsume(queue: "ApplicationNotifications", autoAck: false, consumer: consumer);

    await next(context);
});



app.Use(async (context, next) =>
{
    var userManager = context.RequestServices.GetRequiredService<UserManager<ApplicationUser>>();
    var user = userManager.GetUserAsync(context.User).Result;
    var _hubContext = context.RequestServices.GetRequiredService<IHubContext<OnlinePresenceIndicatorHub>>();
    var _messagePublisher = context.RequestServices.GetRequiredService<IMessageProducer>();

    var factory = new ConnectionFactory
    {
        HostName = "localhost",
        DispatchConsumersAsync = false,
        ConsumerDispatchConcurrency = 1,
    };
    using var connection = factory.CreateConnection();
    using var channel = connection.CreateModel();

    channel.QueueDeclare("OnlinePresenceIndications",
            durable: false,
            exclusive: false,
            autoDelete: true,
            arguments: null);

    var consumer = new EventingBasicConsumer(channel);
    consumer.Received += async (model, eventArgs) =>
    {
        var body = eventArgs.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);
        channel.BasicAck(eventArgs.DeliveryTag, false);
        await _hubContext!.Clients.All.SendAsync("SendOnlinePresence", message);
    };
    channel.BasicConsume(queue: "OnlinePresenceIndications", autoAck: false, consumer: consumer);

    if (user is not null)
    {
        var utcOPI = user.OnlinePresenceIndicator?.ToUniversalTime();
        if (DateTime.UtcNow < utcOPI?.AddMinutes(1))
        {
            _messagePublisher.SendOnlinePresence(new OnlinePresence(user, OnlinePresenceStatus.ONLINE));
        }
    }
    await next(context);
});



app.Run();
