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
    public class CalendarController : Controller
    {
        private readonly GoalTrackerContext _context;

        public CalendarController(GoalTrackerContext context)
        {
            _context = context;
        }

        // GET: Calendar
        public async Task<IActionResult> Index()
        {
              return _context.Calendar != null ? 
                          View(await _context.Calendar.ToListAsync()) :
                          Problem("Entity set 'GoalTrackerContext.Calendar'  is null.");
        }

        // GET: Calendar/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Calendar == null)
            {
                return NotFound();
            }

            var calendar = await _context.Calendar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calendar == null)
            {
                return NotFound();
            }

            return View(calendar);
        }

        // GET: Calendar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Calendar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ParentId,Title,Description,CreatedDate,StartedDate,TargetDate,CompletedDate,Completed,Favorited,Category,Icon,Color")] Calendar calendar)
        {
            if (ModelState.IsValid)
            {
                calendar.Id = Guid.NewGuid();
                _context.Add(calendar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(calendar);
        }

        // GET: Calendar/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Calendar == null)
            {
                return NotFound();
            }

            var calendar = await _context.Calendar.FindAsync(id);
            if (calendar == null)
            {
                return NotFound();
            }
            return View(calendar);
        }

        // POST: Calendar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,ParentId,Title,Description,CreatedDate,StartedDate,TargetDate,CompletedDate,Completed,Favorited,Category,Icon,Color")] Calendar calendar)
        {
            if (id != calendar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calendar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalendarExists(calendar.Id))
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
            return View(calendar);
        }

        // GET: Calendar/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Calendar == null)
            {
                return NotFound();
            }

            var calendar = await _context.Calendar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calendar == null)
            {
                return NotFound();
            }

            return View(calendar);
        }

        // POST: Calendar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Calendar == null)
            {
                return Problem("Entity set 'GoalTrackerContext.Calendar'  is null.");
            }
            var calendar = await _context.Calendar.FindAsync(id);
            if (calendar != null)
            {
                _context.Calendar.Remove(calendar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalendarExists(Guid id)
        {
          return (_context.Calendar?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}