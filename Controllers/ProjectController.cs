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
    public class ProjectController : Controller
    {
        private readonly GoalTrackerContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public ProjectController(GoalTrackerContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Project
        public async Task<IActionResult> Index()
        {
            var projects = _context.Project.Include(t => t.Parent).Include(t => t.CreatedBy);
            return View(await projects.ToListAsync());
        }

        // GET: Project/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Project == null)
            {
                return NotFound();
            }

            var project = await _context.Project
                .FirstOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Project/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Project/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ParentId,Title,Description,CreatedDate,StartedDate,TargetDate,CompletedDate,Completed,Favorited,Category,Icon,Color")] Project project)
        {
            var user = _userManager.GetUserAsync(User).Result;

            if (user is not null)
            {
                if (ModelState.IsValid)
                {
                    project.Id = Guid.NewGuid();
                    project.CreatedBy = user;
                    project.CreatedDate = DateTime.Now;
                    _context.Add(project);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }                
            }
            return View(project);
        }

        // GET: Project/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Project == null)
            {
                return NotFound();
            }

            var project = await _context.Project.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        // POST: Project/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,ParentId,Title,Description,CreatedDate,StartedDate,TargetDate,CompletedDate,Completed,Favorited,Category,Icon,Color")] Project project)
        {
            if (id != project.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.Id))
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
            return View(project);
        }

        // GET: Project/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Project == null)
            {
                return NotFound();
            }

            var project = await _context.Project
                .FirstOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Project == null)
            {
                return Problem("Entity set 'GoalTrackerContext.Project'  is null.");
            }
            var project = await _context.Project.FindAsync(id);
            if (project != null)
            {
                _context.Project.Remove(project);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(Guid id)
        {
          return (_context.Project?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
