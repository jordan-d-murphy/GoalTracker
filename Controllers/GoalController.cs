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
    public class GoalController : Controller
    {
        private readonly GoalTrackerContext _context;

        public GoalController(GoalTrackerContext context)
        {
            _context = context;
        }

        // GET: Goal
        public async Task<IActionResult> Index(string searchString)
        {
            if (_context.Goal == null || _context.Milestone == null || _context.ActivityEntry == null)
            {
                return Problem("One or more Entity Sets is null.");
            }

            var goals = from g in _context.Goal select g;
            var milestones = from m in _context.Milestone select m;
            var activities = from a in _context.ActivityEntry select a;

            GoalListMilestonesViewModel listViewModel = new GoalListMilestonesViewModel();

            if (!String.IsNullOrEmpty(searchString))
            {
        
                var activityMatches = activities.Where(a => a.Title!.Contains(searchString) ||
                    a.Description!.Contains(searchString) ||
                    a.Category!.Contains(searchString));

                var milestoneMatchIds = activityMatches.Select(a => a.MilestoneId).ToList();

                var milestoneMatches = milestones.Where(m => m.Title!.Contains(searchString) ||
                    m.Description!.Contains(searchString) ||
                    m.Category!.Contains(searchString) || milestoneMatchIds.Contains(m.Id));

                var goalMatchIds = milestoneMatches.Select(m => m.GoalId).ToList();
                    
                var goalMatches = goals.Where(g => g.Title!.Contains(searchString) ||
                    g.Description!.Contains(searchString) ||
                    g.Category!.Contains(searchString) || goalMatchIds.Contains(g.Id));

                listViewModel = new GoalListMilestonesViewModel
                {
                    Goals = await goalMatches.ToListAsync(),
                    Milestones = await milestoneMatches.ToListAsync(),            
                    ActivityEntries = await activityMatches.ToListAsync()                            
                };                          

            }  
            else 
            {
                listViewModel = new GoalListMilestonesViewModel
                {
                    Goals = await goals.ToListAsync(),
                    Milestones = await milestones.ToListAsync(),            
                    ActivityEntries = await activities.ToListAsync()                             
                };
            }      

            return View(listViewModel);
        }

        // GET: Goal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Goal == null)
            {
                return NotFound();
            }

            var goal = await _context.Goal
                .FirstOrDefaultAsync(m => m.Id == id);
            if (goal == null)
            {
                return NotFound();
            }

            var milestones = from m in _context.Milestone select m;
            milestones = milestones.Where(m => m.GoalId == goal.Id);

            var detailViewModel = new GoalDetailMilestoneActivityViewModel
            {
                Goal = goal,
                Milestones = await milestones.ToListAsync()
            };

            return View(detailViewModel);
        }

        // GET: Goal/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Goal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,CreatedDate,TargetDate,Completed,CompletedDate,Category")] Goal goal)
        {
            goal.CreatedDate = DateTime.Today;

            if (ModelState.IsValid)
            {
                _context.Add(goal);
                await _context.SaveChangesAsync();
                // return RedirectToAction(nameof(Index));
                return RedirectToAction(nameof(Index), "Goal", new {}, $"GoalCard_{goal.Id}");

            }
            return View(goal);
        }

        // GET: Goal/Edit/5
        public async Task<IActionResult> Edit(int? id)
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
            return View(goal);
        }

        // POST: Goal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,CreatedDate,TargetDate,Completed,CompletedDate,Category")] Goal goal)
        {
            if (id != goal.Id)
            {
                return NotFound();
            }

            if (goal.Completed)
            {
                goal.CompletedDate = DateTime.Today;
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(goal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GoalExists(goal.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), "Goal", new {}, $"GoalCard_{goal.Id}");
            }
            return View(goal);
        }

        // GET: Goal/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Goal == null)
            {
                return NotFound();
            }

            var goal = await _context.Goal
                .FirstOrDefaultAsync(m => m.Id == id);
            if (goal == null)
            {
                return NotFound();
            }

            return View(goal);
        }

        // POST: Goal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Goal == null)
            {
                return Problem("Entity set 'GoalTrackerContext.Goal'  is null.");
            }
            var goal = await _context.Goal.FindAsync(id);
            if (goal != null)
            {
                _context.Goal.Remove(goal);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GoalExists(int id)
        {
            return (_context.Goal?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
