using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GoalTracker.Data;
using GoalTracker.Models;

namespace GoalTracker.Controllers
{
    public class PriorityController : Controller
    {
        private readonly GoalTrackerContext _context;

        public PriorityController(GoalTrackerContext context)
        {
            _context = context;
        }

        // GET: Priority
        public async Task<IActionResult> Index()
        {
              return _context.Priority != null ? 
                          View(await _context.Priority.ToListAsync()) :
                          Problem("Entity set 'GoalTrackerContext.Priority'  is null.");
        }

        // GET: Priority/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Priority == null)
            {
                return NotFound();
            }

            var priority = await _context.Priority
                .FirstOrDefaultAsync(m => m.Id == id);
            if (priority == null)
            {
                return NotFound();
            }

            return View(priority);
        }

        // GET: Priority/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Priority/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,PriorityInt,CreatedDate")] Priority priority)
        {
            if (ModelState.IsValid)
            {
                priority.Id = Guid.NewGuid();
                _context.Add(priority);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(priority);
        }

        // GET: Priority/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Priority == null)
            {
                return NotFound();
            }

            var priority = await _context.Priority.FindAsync(id);
            if (priority == null)
            {
                return NotFound();
            }
            return View(priority);
        }

        // POST: Priority/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,PriorityInt,CreatedDate")] Priority priority)
        {
            if (id != priority.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(priority);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PriorityExists(priority.Id))
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
            return View(priority);
        }

        // GET: Priority/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Priority == null)
            {
                return NotFound();
            }

            var priority = await _context.Priority
                .FirstOrDefaultAsync(m => m.Id == id);
            if (priority == null)
            {
                return NotFound();
            }

            return View(priority);
        }

        // POST: Priority/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Priority == null)
            {
                return Problem("Entity set 'GoalTrackerContext.Priority'  is null.");
            }
            var priority = await _context.Priority.FindAsync(id);
            if (priority != null)
            {
                _context.Priority.Remove(priority);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PriorityExists(Guid id)
        {
          return (_context.Priority?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
