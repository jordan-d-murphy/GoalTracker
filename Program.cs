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

    string[] roles = { "Admin", "ConfirmedAccount" };

    foreach (var role in roles)
    {
        var roleExists = await roleManager.RoleExistsAsync(role);
        if (!roleExists)
        {
            await roleManager.CreateAsync(new ApplicationRole() { Name = role });
        }
    }

    // Create Admin user if does not exist
    var adminUserName = builder.Configuration["AdminUserName"];
    var adminEmail = builder.Configuration["AdminEmail"];
    var adminPassword = builder.Configuration["AdminPassword"];

    if (String.IsNullOrEmpty(adminUserName) || String.IsNullOrEmpty(adminEmail) || String.IsNullOrEmpty(adminPassword))
    {
        // unable to fetch config 
        throw new ConfigurationErrorsException("Unable to read AppSettings.json");
    }
    else
    {
        var success = await Utils.CreateUser(adminUserName, adminEmail, adminPassword, roles, userManager);
    }

    // Create Test user if does not exist
    var testUserUserName = builder.Configuration["TestUserUserName"];
    var testUserEmail = builder.Configuration["TestUserEmail"];
    var testUserPassword = builder.Configuration["TestUserPassword"];

    if (String.IsNullOrEmpty(testUserUserName) || String.IsNullOrEmpty(testUserEmail) || String.IsNullOrEmpty(testUserPassword))
    {
        // unable to fetch config 
        throw new ConfigurationErrorsException("Unable to read AppSettings.json");
    }
    else
    {
        var success = await Utils.CreateUser(testUserUserName, testUserEmail, testUserPassword, new string[] { "ConfirmedAccount" }, userManager);
    }







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



app.Use(async (context, next) =>
{
    var userManager = context.RequestServices.GetRequiredService<UserManager<ApplicationUser>>();
    var user = userManager.GetUserAsync(context.User).Result;

    if (user is not null)
    {
        var msgLoggedIn = $" \n\nThis is from the middleware... howdy, {user.Email}!\n\n ";
        System.Diagnostics.Debug.WriteLine(msgLoggedIn);
    }
    else
    {
        var msgGuest = $" \n\nThis is from the middleware... howdy, Guest User!\n\n ";
        System.Diagnostics.Debug.WriteLine(msgGuest);
    }






    var _hubContext = context.RequestServices.GetRequiredService<IHubContext<NotificationHub>>();

    // var factory = new ConnectionFactory { HostName = "localhost" };

    var factory = new ConnectionFactory
    {
        HostName = "localhost",
        DispatchConsumersAsync = false,
        ConsumerDispatchConcurrency = 1,
    };
    using var connection = factory.CreateConnection();
    using var channel = connection.CreateModel();
    // var channel = connection.CreateModel();

    channel.QueueDeclare("ApplicationNotifications",
            durable: false,
            exclusive: false,
            autoDelete: true,
            arguments: null);




    var consumer = new EventingBasicConsumer(channel);
    consumer.Received += async (model, eventArgs) =>
    {

        System.Diagnostics.Debug.WriteLine(" \n\n\nconsumer.Received += async (model, eventArgs) =>\n\n\n ");

        var body = eventArgs.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);
        channel.BasicAck(eventArgs.DeliveryTag, false);
        // var user = _userManager.FindByEmailAsync("");
        // await _hubContext.Clients.All.SendAsync("SendMessage", $"Notification send: {DateTime.Now}, Message: {message}");
        await _hubContext!.Clients.All.SendAsync("ReceiveMessage", message);


    };

    channel.BasicConsume(queue: "ApplicationNotifications", autoAck: false, consumer: consumer);

    await next(context);
});

// app.Run(async (context) =>
// {   
// });





app.Run();
