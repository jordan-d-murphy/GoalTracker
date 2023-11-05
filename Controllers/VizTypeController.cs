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
    public class VizTypeController : Controller
    {
        private readonly GoalTrackerContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public VizTypeController(GoalTrackerContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: VizType
        public async Task<IActionResult> Index()
        {
            var vizTypes = _context.VizType
                .Join(_userManager.Users,
                vizType => vizType.CreatedBy,
                user => user,
                (vizType, user) => new VizTypeIndexViewModel
                {
                    VizType = vizType,
                    CreatedUser = user
                });
            return View(await vizTypes.ToListAsync());
        }

        // GET: VizType/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.VizType == null)
            {
                return NotFound();
            }

            var vizType = await _context.VizType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vizType == null)
            {
                return NotFound();
            }

            return View(vizType);
        }

        // GET: VizType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VizType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ParentId,Title,Name,JSONData,Description,CreatedDate,StartedDate,TargetDate,CompletedDate,Completed,Favorited,Category,Icon,Color")] VizType vizType)
        {
            var user = _userManager.GetUserAsync(User).Result;

            if (user is not null)
            {
                if (ModelState.IsValid)
                {
                    vizType.Id = Guid.NewGuid();
                    vizType.CreatedBy = user;
                    vizType.CreatedDate = DateTime.Now;
                    _context.Add(vizType);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(vizType);
        }

        // GET: VizType/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.VizType == null)
            {
                return NotFound();
            }

            var vizType = await _context.VizType.FindAsync(id);
            if (vizType == null)
            {
                return NotFound();
            }
            return View(vizType);
        }

        // POST: VizType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,ParentId,Title,Name,JSONData,Description,CreatedDate,StartedDate,TargetDate,CompletedDate,Completed,Favorited,Category,Icon,Color")] VizType vizType)
        {
            if (id != vizType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vizType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VizTypeExists(vizType.Id))
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
            return View(vizType);
        }

        // GET: VizType/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.VizType == null)
            {
                return NotFound();
            }

            var vizType = await _context.VizType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vizType == null)
            {
                return NotFound();
            }

            return View(vizType);
        }

        // POST: VizType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.VizType == null)
            {
                return Problem("Entity set 'GoalTrackerContext.VizType'  is null.");
            }
            var vizType = await _context.VizType.FindAsync(id);
            if (vizType != null)
            {
                _context.VizType.Remove(vizType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VizTypeExists(Guid id)
        {
          return (_context.VizType?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
