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
    public class DashVizController : Controller
    {
        private readonly GoalTrackerContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public DashVizController(GoalTrackerContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: DashViz
        public async Task<IActionResult> Index()
        {
            var dashVizs = _context.DashViz.Include(t => t.Parent).Include(t => t.CreatedBy);
            return View(await dashVizs.ToListAsync());
        }

        // GET: DashViz/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.DashViz == null)
            {
                return NotFound();
            }

            var dashViz = await _context.DashViz
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dashViz == null)
            {
                return NotFound();
            }

            return View(dashViz);
        }

        // GET: DashViz/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DashViz/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,JSONData,Id,ParentId,Title,Description,CreatedDate,StartedDate,TargetDate,CompletedDate,Completed,Favorited,Category,Icon,Color")] DashViz dashViz)
        {            
            var user = _userManager.GetUserAsync(User).Result;

            if (user is not null)
            {
                if (ModelState.IsValid)
                {
                    if (dashViz.ParentId is not null)
                    {
                        var dash = await _context.Dash.Include(m => m.Vizualizations)
                            .FirstOrDefaultAsync(m => m.Id == dashViz.ParentId);
                        if (dash is not null)
                        {
                            if (dash.Vizualizations is null)
                            {
                                dash.Vizualizations = new List<DashViz>();
                            }                            
                            if (dash is not null)
                            {
                                dash.Vizualizations!.Add(dashViz);                                
                            }
                        }
                    }

                    dashViz.Id = Guid.NewGuid();
                    dashViz.CreatedBy = user;
                    dashViz.CreatedDate = DateTime.Now;
                    _context.Add(dashViz);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Details), "Dash", new { id = dashViz.ParentId } );
                }
            }
            return View(dashViz);
        }

        // GET: DashViz/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.DashViz == null)
            {
                return NotFound();
            }

            var dashViz = await _context.DashViz.FindAsync(id);
            if (dashViz == null)
            {
                return NotFound();
            }
            return View(dashViz);
        }

        // POST: DashViz/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,JSONData,Id,ParentId,Title,Description,CreatedDate,StartedDate,TargetDate,CompletedDate,Completed,Favorited,Category,Icon,Color")] DashViz dashViz)
        {
            if (id != dashViz.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dashViz);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DashVizExists(dashViz.Id))
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
            return View(dashViz);
        }

        // GET: DashViz/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.DashViz == null)
            {
                return NotFound();
            }

            var dashViz = await _context.DashViz
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dashViz == null)
            {
                return NotFound();
            }

            return View(dashViz);
        }

        // POST: DashViz/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.DashViz == null)
            {
                return Problem("Entity set 'GoalTrackerContext.DashViz'  is null.");
            }
            var dashViz = await _context.DashViz.FindAsync(id);
            if (dashViz != null)
            {
                _context.DashViz.Remove(dashViz);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DashVizExists(Guid id)
        {
            return (_context.DashViz?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
