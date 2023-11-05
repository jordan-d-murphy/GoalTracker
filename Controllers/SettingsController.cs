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
    public class SettingsController : Controller
    {
        private readonly GoalTrackerContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public SettingsController(GoalTrackerContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Settings
        public async Task<IActionResult> Index()
        {
            var settings = _context.Settings.Include(t => t.Parent).Include(t => t.CreatedBy);
            return View(await settings.ToListAsync());
        }

        // GET: Settings/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Settings == null)
            {
                return NotFound();
            }

            var settings = await _context.Settings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (settings == null)
            {
                return NotFound();
            }

            return View(settings);
        }

        // GET: Settings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Settings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,JSONData,Id,ParentId,Title,Description,CreatedDate,StartedDate,TargetDate,CompletedDate,Completed,Favorited,Category,Icon,Color")] Settings settings)
        {
            var user = _userManager.GetUserAsync(User).Result;

            if (user is not null)
            {
                if (ModelState.IsValid)
                {
                    settings.Id = Guid.NewGuid();
                    settings.CreatedBy = user;
                    settings.CreatedDate = DateTime.Now;
                    _context.Add(settings);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(settings);
        }

        // GET: Settings/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Settings == null)
            {
                return NotFound();
            }

            var settings = await _context.Settings.FindAsync(id);
            if (settings == null)
            {
                return NotFound();
            }
            return View(settings);
        }

        // POST: Settings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,JSONData,Id,ParentId,Title,Description,CreatedDate,StartedDate,TargetDate,CompletedDate,Completed,Favorited,Category,Icon,Color")] Settings settings)
        {
            if (id != settings.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(settings);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SettingsExists(settings.Id))
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
            return View(settings);
        }

        // GET: Settings/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Settings == null)
            {
                return NotFound();
            }

            var settings = await _context.Settings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (settings == null)
            {
                return NotFound();
            }

            return View(settings);
        }

        // POST: Settings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Settings == null)
            {
                return Problem("Entity set 'GoalTrackerContext.Settings'  is null.");
            }
            var settings = await _context.Settings.FindAsync(id);
            if (settings != null)
            {
                _context.Settings.Remove(settings);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SettingsExists(Guid id)
        {
          return (_context.Settings?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
