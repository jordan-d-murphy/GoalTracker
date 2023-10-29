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
    public class MetricTypeController : Controller
    {
        private readonly GoalTrackerContext _context;

        public MetricTypeController(GoalTrackerContext context)
        {
            _context = context;
        }

        // GET: MetricType
        public async Task<IActionResult> Index()
        {
              return _context.MetricType != null ? 
                          View(await _context.MetricType.ToListAsync()) :
                          Problem("Entity set 'GoalTrackerContext.MetricType'  is null.");
        }

        // GET: MetricType/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.MetricType == null)
            {
                return NotFound();
            }

            var metricType = await _context.MetricType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (metricType == null)
            {
                return NotFound();
            }

            return View(metricType);
        }

        // GET: MetricType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MetricType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] MetricType metricType)
        {
            if (ModelState.IsValid)
            {
                metricType.Id = Guid.NewGuid();
                _context.Add(metricType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(metricType);
        }

        // GET: MetricType/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.MetricType == null)
            {
                return NotFound();
            }

            var metricType = await _context.MetricType.FindAsync(id);
            if (metricType == null)
            {
                return NotFound();
            }
            return View(metricType);
        }

        // POST: MetricType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name")] MetricType metricType)
        {
            if (id != metricType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(metricType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MetricTypeExists(metricType.Id))
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
            return View(metricType);
        }

        // GET: MetricType/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.MetricType == null)
            {
                return NotFound();
            }

            var metricType = await _context.MetricType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (metricType == null)
            {
                return NotFound();
            }

            return View(metricType);
        }

        // POST: MetricType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.MetricType == null)
            {
                return Problem("Entity set 'GoalTrackerContext.MetricType'  is null.");
            }
            var metricType = await _context.MetricType.FindAsync(id);
            if (metricType != null)
            {
                _context.MetricType.Remove(metricType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MetricTypeExists(Guid id)
        {
          return (_context.MetricType?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
