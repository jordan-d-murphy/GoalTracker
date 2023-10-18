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
    public class MilestoneController : Controller
    {
        private readonly GoalTrackerContext _context;

        public MilestoneController(GoalTrackerContext context)
        {
            _context = context;
        }

        // GET: Milestone
        public async Task<IActionResult> Index()
        {
              return _context.Milestone != null ? 
                          View(await _context.Milestone.ToListAsync()) :
                          Problem("Entity set 'GoalTrackerContext.Milestone'  is null.");
        }

        // GET: Milestone/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Milestone == null)
            {
                return NotFound();
            }

            var milestone = await _context.Milestone
                .FirstOrDefaultAsync(m => m.Id == id);
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

            var activities = from a in _context.ActivityEntry select a;

            activities = activities.Where(a => a.MilestoneId == milestone.Id);

            milestone.Activities = await activities.ToListAsync();

            return View(milestone);
        }

        // GET: Milestone/Create
        public async Task<IActionResult> Create(int? id)
        {
            if (id == null || _context.Goal == null) 
            {
                return NotFound();
            }

            var goal = await _context.Goal.FindAsync(id);
            if (goal == null) 
            {
                return NotFound();
            }

            var milestone = new Milestone
            {
                Goal = goal,
                GoalId = goal.Id
            };

            return View(milestone);
        }

        // POST: Milestone/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost([Bind("Goal,GoalId,Id,Title,Description,CreatedDate,TargetDate,CompletedDate,Completed,Category,Icon,Color")] Milestone milestone)
        {
            var goal = await _context.Goal.FindAsync(milestone.GoalId);

            if (goal == null)
            {
                return NotFound();
            }

            milestone.Goal = goal;

            ModelState.ClearValidationState(nameof(goal));
            TryValidateModel(goal, nameof(goal));

            if (ModelState.IsValid)
            {
                _context.Add(milestone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(milestone);
        }

        // GET: Milestone/Edit/5
        public async Task<IActionResult> Edit(int? id)
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
            return View(milestone);
        }

        // POST: Milestone/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Goal,GoalId,Id,Title,Description,CreatedDate,TargetDate,CompletedDate,Completed,Category,Icon,Color")] Milestone milestone)
        {
            if (id != milestone.Id)
            {
                return NotFound();
            }

            var goal = await _context.Goal.FindAsync(milestone.GoalId);

            if (goal == null)
            {
                return NotFound();
            }

            milestone.Goal = goal;

            ModelState.ClearValidationState(nameof(goal));
            TryValidateModel(goal, nameof(goal));

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(milestone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MilestoneExists(milestone.Id))
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
            return View(milestone);
        }

        // GET: Milestone/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Milestone == null)
            {
                return NotFound();
            }

            var milestone = await _context.Milestone
                .FirstOrDefaultAsync(m => m.Id == id);
            if (milestone == null)
            {
                return NotFound();
            }

            return View(milestone);
        }

        // POST: Milestone/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Milestone == null)
            {
                return Problem("Entity set 'GoalTrackerContext.Milestone'  is null.");
            }
            var milestone = await _context.Milestone.FindAsync(id);
            if (milestone != null)
            {
                _context.Milestone.Remove(milestone);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MilestoneExists(int id)
        {
          return (_context.Milestone?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
