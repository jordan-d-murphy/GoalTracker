using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GoalTracker.Data;
using RabbitMQ.Client;
using System.Runtime.CompilerServices;
using GoalTracker.RabbitMQ;
using RabbitMQ.Client.Events;
using GoalTracker.Models;
using GoalTracker.Hubs;
using Microsoft.AspNetCore.Identity;
using GoalTracker.Areas.Identity.Data;
using Microsoft.AspNetCore.SignalR;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace GoalTracker.Controllers
{
    public class NotificationController : Controller
    {
        private readonly GoalTrackerContext _context;

        private readonly IMessageProducer _messagePublisher;

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IHubContext<NotificationHub> _hubContext;


        public NotificationController(GoalTrackerContext context, IMessageProducer messagePublisher, UserManager<ApplicationUser> userManager, IHubContext<NotificationHub> hubContext)
        {
            _context = context;
            _messagePublisher = messagePublisher;
            _userManager = userManager;
            _hubContext = hubContext;
        }

        // GET: Notification
        public async Task<IActionResult> Index()
        {
            return _context.Notification != null ?
                        // View(await _context.Notification.Where(n => !n.Read).ToListAsync()) :
                        View(await _context.Notification.Where(n => !n.Read).OrderByDescending(n => n.SentTimestamp).ToListAsync()) :
                        Problem("Entity set 'GoalTrackerContext.Notification'  is nul.");
        }

        public async Task<IActionResult> MyNotifications()
        {

            List<Notification> notifications = new List<Notification>();

            // var factory = new ConnectionFactory { HostName = "localhost" };

            var factory = new ConnectionFactory
                {
                    HostName = "localhost",
                    DispatchConsumersAsync = false,
                    ConsumerDispatchConcurrency = 1,
                };

            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            // var channel = connection.CreateModel();

            channel.QueueDeclare("ApplicationNotifications",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);




            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += async (model, eventArgs) =>
            {
                var body = eventArgs.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                notifications.Add(new Notification() { MessageBody = message, SentTimestamp = DateTime.Now });
                channel.BasicAck(eventArgs.DeliveryTag, false);
                // var user = _userManager.FindByEmailAsync("");
                // await _hubContext.Clients.All.SendAsync("SendMessage", $"Notification send: {DateTime.Now}, Message: {message}");
                await _hubContext.Clients.All.SendAsync("ReceiveMessage", message);


            };

            channel.BasicConsume(queue: "ApplicationNotifications", autoAck: false, consumer: consumer);

            return _context.Notification != null ?
                        // View(await _context.Notification.Where(n => !n.Read).ToListAsync()) :
                        View(await _context.Notification.Where(n => !n.Read).OrderByDescending(n => n.SentTimestamp).ToListAsync()) :
                        Problem("Entity set 'GoalTrackerContext.Notification'  is nul.");

            // return View(notifications);
        }

        // GET: Notification/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Notification == null)
            {
                return NotFound();
            }

            var notification = await _context.Notification
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notification == null)
            {
                return NotFound();
            }

            return View(notification);
        }

        // GET: Notification/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Notification/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MessageBody,SentTimestamp,DeliveredTimestamp,ReadTimestamp,Read,GeneratedByApplication")] Notification notification)
        {
            if (ModelState.IsValid)
            {
                notification.Id = Guid.NewGuid();
                notification.SentTimestamp = DateTime.Now;
                _context.Add(notification);
                await _context.SaveChangesAsync();

                _messagePublisher.SendMessage(notification);
                // _hubContext.Clients.All.SendAsync("ReceiveMessage", $"Notification send: {DateTime.Now}, Message: {notification}");

                return RedirectToAction(nameof(Index));
            }
            return View(notification);
        }

        // GET: Notification/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Notification == null)
            {
                return NotFound();
            }

            var notification = await _context.Notification.FindAsync(id);
            if (notification == null)
            {
                return NotFound();
            }
            return View(notification);
        }

        // POST: Notification/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,MessageBody,SentTimestamp,DeliveredTimestamp,ReadTimestamp,Read,GeneratedByApplication")] Notification notification)
        {
            if (id != notification.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotificationExists(notification.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(notification);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<bool> MarkAsRead(Guid id)
        {
            if (_context.Notification == null)
            {
                return false;
            }

            var notification = await _context.Notification.FindAsync(id);
            if (notification == null)
            {
                return false;
            }

            try
            {
                notification.Read = true;
                _context.Update(notification);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotificationExists(notification.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            return true;
        }

        [AllowAnonymous]
        public int GetCountUnreadNotifications()
        {
            if (_context.Notification == null)
            {
                return 0;
            }

            var count = _context.Notification.Where(n => !n.Read).Count();            
            return count;
        }

        [AllowAnonymous]
        public async void ClearNotificationIcon()
        {
            await _hubContext.Clients.All.SendAsync("ClearNotificationIcon", true);
        }

        // GET: Notification/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Notification == null)
            {
                return NotFound();
            }

            var notification = await _context.Notification
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notification == null)
            {
                return NotFound();
            }

            return View(notification);
        }

        // POST: Notification/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Notification == null)
            {
                return Problem("Entity set 'GoalTrackerContext.Notification'  is null.");
            }
            var notification = await _context.Notification.FindAsync(id);
            if (notification != null)
            {
                _context.Notification.Remove(notification);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotificationExists(Guid id)
        {
            return (_context.Notification?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
