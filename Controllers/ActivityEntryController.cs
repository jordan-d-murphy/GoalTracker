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
using System.Collections.Immutable;

namespace GoalTracker.Controllers
{
    [Authorize(Roles = "ConfirmedAccount")]
    public class ActivityEntryController : Controller
    {
        private readonly GoalTrackerContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public ActivityEntryController(GoalTrackerContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: ActivityEntry
        public async Task<IActionResult> Index()
        {                       
            var activities = _context.ActivityEntry.Include(t => t.Parent).Include(t => t.CreatedBy);
            return View(await activities.ToListAsync());
        }

        // GET: ActivityEntry/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.ActivityEntry == null)
            {
                return NotFound();
            }

            var activityEntry = await _context.ActivityEntry
                .FirstOrDefaultAsync(m => m.Id == id);
            if (activityEntry == null)
            {
                return NotFound();
            }

            return View(activityEntry);
        }

        // GET: ActivityEntry/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ActivityEntry/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ParentId,Title,Description,CreatedDate,StartedDate,TargetDate,CompletedDate,Completed,Favorited,Category,Icon,Color")] ActivityEntry activityEntry)
        {
            var user = _userManager.GetUserAsync(User).Result;

            if (user is not null)
            {
                if (ModelState.IsValid)
                {
                    activityEntry.Id = Guid.NewGuid();
                    activityEntry.CreatedBy = user;
                    activityEntry.CreatedDate = DateTime.Now;
                    _context.Add(activityEntry);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(activityEntry);
        }

        // GET: ActivityEntry/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.ActivityEntry == null)
            {
                return NotFound();
            }

            var activityEntry = await _context.ActivityEntry.FindAsync(id);
            if (activityEntry == null)
            {
                return NotFound();
            }
            return View(activityEntry);
        }

        // POST: ActivityEntry/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,ParentId,Title,Description,CreatedDate,StartedDate,TargetDate,CompletedDate,Completed,Favorited,Category,Icon,Color")] ActivityEntry activityEntry)
        {
            if (id != activityEntry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activityEntry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivityEntryExists(activityEntry.Id))
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
            return View(activityEntry);
        }

        // GET: ActivityEntry/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.ActivityEntry == null)
            {
                return NotFound();
            }

            var activityEntry = await _context.ActivityEntry
                .FirstOrDefaultAsync(m => m.Id == id);
            if (activityEntry == null)
            {
                return NotFound();
            }

            return View(activityEntry);
        }

        // POST: ActivityEntry/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.ActivityEntry == null)
            {
                return Problem("Entity set 'GoalTrackerContext.ActivityEntry'  is null.");
            }
            var activityEntry = await _context.ActivityEntry.FindAsync(id);
            if (activityEntry != null)
            {
                _context.ActivityEntry.Remove(activityEntry);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActivityEntryExists(Guid id)
        {
            return (_context.ActivityEntry?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
