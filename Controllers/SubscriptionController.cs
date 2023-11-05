using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GoalTracker.Data;
using GoalTracker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using GoalTracker.Areas.Identity.Data;

namespace GoalTracker.Controllers
{
    [Authorize(Roles = "ConfirmedAccount")]
    public class SubscriptionController : Controller
    {
        private readonly GoalTrackerContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public SubscriptionController(GoalTrackerContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Subscription
        public async Task<IActionResult> Index()
        {
            var subscriptions = _context.Subscription.Include(t => t.CreatedBy);
            return View(await subscriptions.ToListAsync());
        }

        // GET: Subscription/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Subscription == null)
            {
                return NotFound();
            }

            var subscription = await _context.Subscription
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subscription == null)
            {
                return NotFound();
            }

            return View(subscription);
        }

        // GET: Subscription/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Subscription/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tier,Name,Price,Details,BillingFrequency")] Subscription subscription)
        {
            var user = _userManager.GetUserAsync(User).Result;

            if (user is not null)
            {
                if (ModelState.IsValid)
                {
                    subscription.Id = Guid.NewGuid();
                    subscription.CreatedBy = user;
                    subscription.CreatedDate = DateTime.Now;
                    _context.Add(subscription);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(subscription);
        }

        // GET: Subscription/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Subscription == null)
            {
                return NotFound();
            }

            var subscription = await _context.Subscription.FindAsync(id);
            if (subscription == null)
            {
                return NotFound();
            }
            return View(subscription);
        }

        // POST: Subscription/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Tier,Name,Price,Details,BillingFrequency")] Subscription subscription)
        {
            if (id != subscription.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subscription);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubscriptionExists(subscription.Id))
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
            return View(subscription);
        }

        // GET: Subscription/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Subscription == null)
            {
                return NotFound();
            }

            var subscription = await _context.Subscription
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subscription == null)
            {
                return NotFound();
            }

            return View(subscription);
        }

        // POST: Subscription/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Subscription == null)
            {
                return Problem("Entity set 'GoalTrackerContext.Subscription'  is null.");
            }
            var subscription = await _context.Subscription.FindAsync(id);
            if (subscription != null)
            {
                _context.Subscription.Remove(subscription);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubscriptionExists(Guid id)
        {
          return (_context.Subscription?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
