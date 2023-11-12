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
using Newtonsoft.Json;


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
            var projects = await _context.Project.ToListAsync();
            var roadmaps = await _context.Roadmap.ToListAsync();
            var goals = await _context.Goal.ToListAsync();
            var milestones = await _context.Milestone.ToListAsync();
            var activities = await _context.ActivityEntry.ToListAsync();


            var calendar = new CalendarViewModel
            {
                Projects = projects,
                RoadMaps = roadmaps,
                Goals = goals,
                Milestones = milestones,
                Activities = activities              
            };

            return View(calendar);

            // return _context.Calendar != null ?
            //             View(await _context.Calendar.ToListAsync()) :
            //             Problem("Entity set 'GoalTrackerContext.Calendar'  is null.");
        }

        [AllowAnonymous]
        public async Task<string> ProjectEvents()
        {
            if (_context.Project == null)
            {
                return JsonConvert.SerializeObject(new Project() {});
            }

            var projects = await _context.Project.ToListAsync(); 
            return JsonConvert.SerializeObject(projects);
        }

         [AllowAnonymous]
        public async Task<string> RoadmapEvents()
        {
            if (_context.Roadmap == null)
            {
                return JsonConvert.SerializeObject(new Roadmap() {});
            }

            var roadmaps = await _context.Roadmap.ToListAsync(); 
            return JsonConvert.SerializeObject(roadmaps);
        }

         [AllowAnonymous]
        public async Task<string> GoalEvents()
        {
            if (_context.Goal == null)
            {
                return JsonConvert.SerializeObject(new Goal() {});
            }

            var goals = await _context.Goal.ToListAsync(); 
            return JsonConvert.SerializeObject(goals);
        }

         [AllowAnonymous]
        public async Task<string> MilestoneEvents()
        {
            if (_context.Milestone == null)
            {
                return JsonConvert.SerializeObject(new Milestone() {});
            }

            var milestones = await _context.Milestone.ToListAsync(); 
            return JsonConvert.SerializeObject(milestones);
        }

         [AllowAnonymous]
        public async Task<string> ActivityEvents()
        {
            if (_context.ActivityEntry == null)
            {
                return JsonConvert.SerializeObject(new ActivityEntry() {});
            }

            var activities = await _context.ActivityEntry.ToListAsync(); 
            return JsonConvert.SerializeObject(activities);
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
