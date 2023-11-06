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
using Producer.RabbitMQ;
using RabbitMQ.Client.Events;
using GoalTracker.Models;

namespace GoalTracker.Controllers
{
    public class NotificationController : Controller
    {
        private readonly GoalTrackerContext _context;

        private readonly IMessageProducer _messagePublisher;

        public NotificationController(GoalTrackerContext context, IMessageProducer messagePublisher)
        {
            _context = context;
            _messagePublisher = messagePublisher;
        }

        // GET: Notification
        public async Task<IActionResult> Index()
        {
            return _context.Notification != null ?
                        View(await _context.Notification.ToListAsync()) :
                        Problem("Entity set 'GoalTrackerContext.Notification'  is null.");
        }

        public async Task<IActionResult> MyNotifications()
        {

            List<Notification> notifications = new List<Notification>();

            var factory = new ConnectionFactory { HostName = "localhost" };
            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare("ApplicationNotifications",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);




            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, eventArgs) =>
            {
                var body = eventArgs.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                notifications.Add(new Notification() { MessageBody = message });
                System.Diagnostics.Debug.WriteLine(message);
            };

            channel.BasicConsume(queue: "ApplicationNotifications", autoAck: false, consumer: consumer);




            return View(notifications);
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
                _context.Add(notification);
                await _context.SaveChangesAsync();

                _messagePublisher.SendMessage(notification);

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
