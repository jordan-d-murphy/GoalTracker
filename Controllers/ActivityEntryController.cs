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
    public class ActivityEntryController : Controller
    {
        private readonly GoalTrackerContext _context;

        public ActivityEntryController(GoalTrackerContext context)
        {
            _context = context;
        }

        // GET: ActivityEntry
        public async Task<IActionResult> Index()
        {
              return _context.ActivityEntry != null ? 
                          View(await _context.ActivityEntry.ToListAsync()) :
                          Problem("Entity set 'GoalTrackerContext.ActivityEntry'  is null.");
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

            var milestone = await _context.Milestone.FindAsync(activityEntry.MilestoneId);
            if (milestone == null) 
            {
                return NotFound();
            }

            var goal = await _context.Goal.FindAsync(milestone.GoalId);

            if (goal == null) 
            {
                return NotFound();
            }

            milestone.Goal = goal;
            activityEntry.Milestone = milestone;            

            return View(activityEntry);
        }

        // GET: ActivityEntry/Create
        public async Task<IActionResult> Create(Guid? id)
        {
            if (id == null || _context.Milestone == null) 
            {
                return NotFound();
            }

            var milestone = await _context.Milestone.FindAsync(id);
            if (milestone == null) 
            {
                return NotFound();
            }

            var goal = await _context.Goal.FindAsync(milestone.GoalId);

            if (goal == null) 
            {
                return NotFound();
            }

            milestone.Goal = goal;

            var activityEntry = new ActivityEntry
            {
                Milestone = milestone,
                MilestoneId = milestone.Id
            };

            return View(activityEntry);
        }

        // POST: ActivityEntry/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost([Bind("Milestone,MilestoneId,Activities,Id,Title,Description,CreatedDate,StartedDate,TargetDate,CompletedDate,Completed,Favorited,Category,Icon,Color,FileAttachments,Links,Tags,CreatedBy,Assignee,Reviewer,Status,Priority")] ActivityEntry activityEntry)
        {
            var milestone = await _context.Milestone.FindAsync(activityEntry.MilestoneId);

            if (milestone == null) 
            {
                return NotFound();
            }            

            var goal = await _context.Goal.FindAsync(milestone.GoalId);

            if (goal == null)
            {
                return NotFound();
            }

            milestone.Goal = goal;
            activityEntry.Milestone = milestone;
            activityEntry.CreatedDate = DateTime.Today;

            ModelState.ClearValidationState(nameof(milestone));
            TryValidateModel(milestone, nameof(milestone));

            if (ModelState.IsValid)
            {
                _context.Add(activityEntry);
                await _context.SaveChangesAsync();
                // return RedirectToAction(nameof(Index));
                return RedirectToAction(nameof(Index), "Goal", new {}, $"GoalCard_{goal.Id}");

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
        public async Task<IActionResult> Edit(Guid id, [Bind("Milestone,MilestoneId,Activities,Id,Title,Description,CreatedDate,StartedDate,TargetDate,CompletedDate,Completed,Favorited,Category,Icon,Color,FileAttachments,Links,Tags,CreatedBy,Assignee,Reviewer,Status,Priority")] ActivityEntry activityEntry)
        {
            if (id != activityEntry.Id)
            {
                return NotFound();
            }

            var milestone = await _context.Milestone.FindAsync(activityEntry.MilestoneId);

            if (milestone == null) 
            {
                return NotFound();
            }            

            var goal = await _context.Goal.FindAsync(milestone.GoalId);

            if (goal == null)
            {
                return NotFound();
            }

            milestone.Goal = goal;
            activityEntry.Milestone = milestone;

            ModelState.ClearValidationState(nameof(milestone));
            TryValidateModel(milestone, nameof(milestone));

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
                // return RedirectToAction(nameof(Index));
                return RedirectToAction(nameof(Index), "Goal", new {}, $"GoalCard_{goal.Id}");

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
            return RedirectToAction(nameof(Index), "Goal");
        }

        private bool ActivityEntryExists(Guid id)
        {
          return (_context.ActivityEntry?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
