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
    public class RecordPriorityController : Controller
    {
        private readonly GoalTrackerContext _context;

        public RecordPriorityController(GoalTrackerContext context)
        {
            _context = context;
        }

        // GET: RecordPriority
        public async Task<IActionResult> Index()
        {
              return _context.RecordPriority != null ? 
                          View(await _context.RecordPriority.ToListAsync()) :
                          Problem("Entity set 'GoalTrackerContext.RecordPriority'  is null.");
        }

        // GET: RecordPriority/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.RecordPriority == null)
            {
                return NotFound();
            }

            var recordPriority = await _context.RecordPriority
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recordPriority == null)
            {
                return NotFound();
            }

            return View(recordPriority);
        }

        // GET: RecordPriority/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RecordPriority/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PriorityInt,Id,ParentId,Title,Description,CreatedDate,StartedDate,TargetDate,CompletedDate,Completed,Favorited,Category,Icon,Color")] RecordPriority recordPriority)
        {
            if (ModelState.IsValid)
            {
                recordPriority.Id = Guid.NewGuid();
                _context.Add(recordPriority);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recordPriority);
        }

        // GET: RecordPriority/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.RecordPriority == null)
            {
                return NotFound();
            }

            var recordPriority = await _context.RecordPriority.FindAsync(id);
            if (recordPriority == null)
            {
                return NotFound();
            }
            return View(recordPriority);
        }

        // POST: RecordPriority/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("PriorityInt,Id,ParentId,Title,Description,CreatedDate,StartedDate,TargetDate,CompletedDate,Completed,Favorited,Category,Icon,Color")] RecordPriority recordPriority)
        {
            if (id != recordPriority.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recordPriority);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecordPriorityExists(recordPriority.Id))
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
            return View(recordPriority);
        }

        // GET: RecordPriority/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.RecordPriority == null)
            {
                return NotFound();
            }

            var recordPriority = await _context.RecordPriority
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recordPriority == null)
            {
                return NotFound();
            }

            return View(recordPriority);
        }

        // POST: RecordPriority/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.RecordPriority == null)
            {
                return Problem("Entity set 'GoalTrackerContext.RecordPriority'  is null.");
            }
            var recordPriority = await _context.RecordPriority.FindAsync(id);
            if (recordPriority != null)
            {
                _context.RecordPriority.Remove(recordPriority);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecordPriorityExists(Guid id)
        {
          return (_context.RecordPriority?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
