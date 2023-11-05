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
    public class MetricController : Controller
    {
        private readonly GoalTrackerContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public MetricController(GoalTrackerContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Metric
        public async Task<IActionResult> Index()
        {
            var metrics = _context.Metric.Include(t => t.Parent).Include(t => t.CreatedBy);
            return View(await metrics.ToListAsync());
        }

        // GET: Metric/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Metric == null)
            {
                return NotFound();
            }

            var metric = await _context.Metric
                .FirstOrDefaultAsync(m => m.Id == id);
            if (metric == null)
            {
                return NotFound();
            }

            return View(metric);
        }

        // GET: Metric/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Metric/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,MetricType,JSONData,Id,ParentId,Title,Description,CreatedDate,StartedDate,TargetDate,CompletedDate,Completed,Favorited,Category,Icon,Color")] Metric metric)
        {
            var user = _userManager.GetUserAsync(User).Result;

            if (user is not null)
            {
                if (ModelState.IsValid)
                {
                    metric.Id = Guid.NewGuid();
                    metric.CreatedBy = user;
                    metric.CreatedDate = DateTime.Now;
                    _context.Add(metric);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(metric);
        }

        // GET: Metric/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Metric == null)
            {
                return NotFound();
            }

            var metric = await _context.Metric.FindAsync(id);
            if (metric == null)
            {
                return NotFound();
            }
            return View(metric);
        }

        // POST: Metric/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,MetricType,JSONData,Id,ParentId,Title,Description,CreatedDate,StartedDate,TargetDate,CompletedDate,Completed,Favorited,Category,Icon,Color")] Metric metric)
        {
            if (id != metric.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(metric);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MetricExists(metric.Id))
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
            return View(metric);
        }

        // GET: Metric/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Metric == null)
            {
                return NotFound();
            }

            var metric = await _context.Metric
                .FirstOrDefaultAsync(m => m.Id == id);
            if (metric == null)
            {
                return NotFound();
            }

            return View(metric);
        }

        // POST: Metric/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Metric == null)
            {
                return Problem("Entity set 'GoalTrackerContext.Metric'  is null.");
            }
            var metric = await _context.Metric.FindAsync(id);
            if (metric != null)
            {
                _context.Metric.Remove(metric);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MetricExists(Guid id)
        {
          return (_context.Metric?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
