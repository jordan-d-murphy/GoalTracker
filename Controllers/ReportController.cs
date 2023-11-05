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
    public class ReportController : Controller
    {
        private readonly GoalTrackerContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public ReportController(GoalTrackerContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Report
        public async Task<IActionResult> Index()
        {
            var reports = _context.Report.Include(t => t.Parent).Include(t => t.CreatedBy);
            return View(await reports.ToListAsync());
        }

        // GET: Report/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Report == null)
            {
                return NotFound();
            }

            var report = await _context.Report
                .FirstOrDefaultAsync(m => m.Id == id);
            if (report == null)
            {
                return NotFound();
            }

            return View(report);
        }

        // GET: Report/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Report/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,JSONData,Id,ParentId,Title,Description,CreatedDate,StartedDate,TargetDate,CompletedDate,Completed,Favorited,Category,Icon,Color")] Report report)
        {
            var user = _userManager.GetUserAsync(User).Result;

            if (user is not null)
            {
                if (ModelState.IsValid)
                {
                    report.Id = Guid.NewGuid();
                    report.CreatedBy = user;
                    report.CreatedDate = DateTime.Now;
                    _context.Add(report);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(report);
        }

        // GET: Report/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Report == null)
            {
                return NotFound();
            }

            var report = await _context.Report.FindAsync(id);
            if (report == null)
            {
                return NotFound();
            }
            return View(report);
        }

        // POST: Report/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,JSONData,Id,ParentId,Title,Description,CreatedDate,StartedDate,TargetDate,CompletedDate,Completed,Favorited,Category,Icon,Color")] Report report)
        {
            if (id != report.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(report);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReportExists(report.Id))
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
            return View(report);
        }

        // GET: Report/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Report == null)
            {
                return NotFound();
            }

            var report = await _context.Report
                .FirstOrDefaultAsync(m => m.Id == id);
            if (report == null)
            {
                return NotFound();
            }

            return View(report);
        }

        // POST: Report/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Report == null)
            {
                return Problem("Entity set 'GoalTrackerContext.Report'  is null.");
            }
            var report = await _context.Report.FindAsync(id);
            if (report != null)
            {
                _context.Report.Remove(report);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReportExists(Guid id)
        {
          return (_context.Report?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
