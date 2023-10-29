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
    public class RecordStatusController : Controller
    {
        private readonly GoalTrackerContext _context;

        public RecordStatusController(GoalTrackerContext context)
        {
            _context = context;
        }

        // GET: RecordStatus
        public async Task<IActionResult> Index()
        {
              return _context.RecordStatus != null ? 
                          View(await _context.RecordStatus.ToListAsync()) :
                          Problem("Entity set 'GoalTrackerContext.RecordStatus'  is null.");
        }

        // GET: RecordStatus/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.RecordStatus == null)
            {
                return NotFound();
            }

            var recordStatus = await _context.RecordStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recordStatus == null)
            {
                return NotFound();
            }

            return View(recordStatus);
        }

        // GET: RecordStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RecordStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ParentId,Title,Description,CreatedDate,StartedDate,TargetDate,CompletedDate,Completed,Favorited,Category,Icon,Color")] RecordStatus recordStatus)
        {
            if (ModelState.IsValid)
            {
                recordStatus.Id = Guid.NewGuid();
                _context.Add(recordStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recordStatus);
        }

        // GET: RecordStatus/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.RecordStatus == null)
            {
                return NotFound();
            }

            var recordStatus = await _context.RecordStatus.FindAsync(id);
            if (recordStatus == null)
            {
                return NotFound();
            }
            return View(recordStatus);
        }

        // POST: RecordStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,ParentId,Title,Description,CreatedDate,StartedDate,TargetDate,CompletedDate,Completed,Favorited,Category,Icon,Color")] RecordStatus recordStatus)
        {
            if (id != recordStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recordStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecordStatusExists(recordStatus.Id))
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
            return View(recordStatus);
        }

        // GET: RecordStatus/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.RecordStatus == null)
            {
                return NotFound();
            }

            var recordStatus = await _context.RecordStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recordStatus == null)
            {
                return NotFound();
            }

            return View(recordStatus);
        }

        // POST: RecordStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.RecordStatus == null)
            {
                return Problem("Entity set 'GoalTrackerContext.RecordStatus'  is null.");
            }
            var recordStatus = await _context.RecordStatus.FindAsync(id);
            if (recordStatus != null)
            {
                _context.RecordStatus.Remove(recordStatus);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecordStatusExists(Guid id)
        {
          return (_context.RecordStatus?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
