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

namespace GoalTracker.Controllers
{
    [Authorize(Roles = "ConfirmedAccount")]
    public class BillingController : Controller
    {
        private readonly GoalTrackerContext _context;

        public BillingController(GoalTrackerContext context)
        {
            _context = context;
        }

        // GET: Billing
        public async Task<IActionResult> Index()
        {
              return _context.Billing != null ? 
                          View(await _context.Billing.ToListAsync()) :
                          Problem("Entity set 'GoalTrackerContext.Billing'  is null.");
        }

        // GET: Billing/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Billing == null)
            {
                return NotFound();
            }

            var billing = await _context.Billing
                .FirstOrDefaultAsync(m => m.Id == id);
            if (billing == null)
            {
                return NotFound();
            }

            return View(billing);
        }

        // GET: Billing/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Billing/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BillingDate,DueDate,PaidDate,Paid")] Billing billing)
        {
            if (ModelState.IsValid)
            {
                billing.Id = Guid.NewGuid();
                _context.Add(billing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(billing);
        }

        // GET: Billing/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Billing == null)
            {
                return NotFound();
            }

            var billing = await _context.Billing.FindAsync(id);
            if (billing == null)
            {
                return NotFound();
            }
            return View(billing);
        }

        // POST: Billing/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,BillingDate,DueDate,PaidDate,Paid")] Billing billing)
        {
            if (id != billing.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(billing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BillingExists(billing.Id))
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
            return View(billing);
        }

        // GET: Billing/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Billing == null)
            {
                return NotFound();
            }

            var billing = await _context.Billing
                .FirstOrDefaultAsync(m => m.Id == id);
            if (billing == null)
            {
                return NotFound();
            }

            return View(billing);
        }

        // POST: Billing/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Billing == null)
            {
                return Problem("Entity set 'GoalTrackerContext.Billing'  is null.");
            }
            var billing = await _context.Billing.FindAsync(id);
            if (billing != null)
            {
                _context.Billing.Remove(billing);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BillingExists(Guid id)
        {
          return (_context.Billing?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}