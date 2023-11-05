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
    public class RoadmapController : Controller
    {
        private readonly GoalTrackerContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public RoadmapController(GoalTrackerContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Roadmap
        public async Task<IActionResult> Index()
        {
            var roadmaps = _context.Roadmap.Include(t => t.Parent).Include(t => t.CreatedBy);
            return View(await roadmaps.ToListAsync());
        }

        // GET: Roadmap/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Roadmap == null)
            {
                return NotFound();
            }

            var roadmap = await _context.Roadmap
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roadmap == null)
            {
                return NotFound();
            }

            return View(roadmap);
        }

        // GET: Roadmap/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Roadmap/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ParentId,Title,Description,CreatedDate,StartedDate,TargetDate,CompletedDate,Completed,Favorited,Category,Icon,Color")] Roadmap roadmap)
        {
            var user = _userManager.GetUserAsync(User).Result;

            if (user is not null)
            {
                if (ModelState.IsValid)
                {
                    roadmap.Id = Guid.NewGuid();
                    roadmap.CreatedBy = user;
                    roadmap.CreatedDate = DateTime.Now;
                    _context.Add(roadmap);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(roadmap);
        }

        // GET: Roadmap/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Roadmap == null)
            {
                return NotFound();
            }

            var roadmap = await _context.Roadmap.FindAsync(id);
            if (roadmap == null)
            {
                return NotFound();
            }
            return View(roadmap);
        }

        // POST: Roadmap/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,ParentId,Title,Description,CreatedDate,StartedDate,TargetDate,CompletedDate,Completed,Favorited,Category,Icon,Color")] Roadmap roadmap)
        {
            if (id != roadmap.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roadmap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoadmapExists(roadmap.Id))
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
            return View(roadmap);
        }

        // GET: Roadmap/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Roadmap == null)
            {
                return NotFound();
            }

            var roadmap = await _context.Roadmap
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roadmap == null)
            {
                return NotFound();
            }

            return View(roadmap);
        }

        // POST: Roadmap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Roadmap == null)
            {
                return Problem("Entity set 'GoalTrackerContext.Roadmap'  is null.");
            }
            var roadmap = await _context.Roadmap.FindAsync(id);
            if (roadmap != null)
            {
                _context.Roadmap.Remove(roadmap);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoadmapExists(Guid id)
        {
            return (_context.Roadmap?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
