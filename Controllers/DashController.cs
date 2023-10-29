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

namespace GoalTracker.Controllers
{
    [Authorize(Roles = "ConfirmedAccount")]
    public class DashController : Controller
    {
        private readonly GoalTrackerContext _context;

        public DashController(GoalTrackerContext context)
        {
            _context = context;
        }

        // GET: Dash
        public async Task<IActionResult> Index()
        {
              return _context.Dash != null ? 
                          View(await _context.Dash.ToListAsync()) :
                          Problem("Entity set 'GoalTrackerContext.Dash'  is null.");
        }

        // GET: Dash/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Dash == null)
            {
                return NotFound();
            }

            var dash = await _context.Dash
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dash == null)
            {
                return NotFound();
            }

            return View(dash);
        }

        // GET: Dash/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dash/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id,ParentId,Title,Description,CreatedDate,StartedDate,TargetDate,CompletedDate,Completed,Favorited,Category,Icon,Color")] Dash dash)
        {
            if (ModelState.IsValid)
            {
                dash.Id = Guid.NewGuid();
                _context.Add(dash);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dash);
        }

        // GET: Dash/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Dash == null)
            {
                return NotFound();
            }

            var dash = await _context.Dash.FindAsync(id);
            if (dash == null)
            {
                return NotFound();
            }
            return View(dash);
        }

        // POST: Dash/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Id,ParentId,Title,Description,CreatedDate,StartedDate,TargetDate,CompletedDate,Completed,Favorited,Category,Icon,Color")] Dash dash)
        {
            if (id != dash.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dash);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DashExists(dash.Id))
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
            return View(dash);
        }

        // GET: Dash/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Dash == null)
            {
                return NotFound();
            }

            var dash = await _context.Dash
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dash == null)
            {
                return NotFound();
            }

            return View(dash);
        }

        // POST: Dash/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Dash == null)
            {
                return Problem("Entity set 'GoalTrackerContext.Dash'  is null.");
            }
            var dash = await _context.Dash.FindAsync(id);
            if (dash != null)
            {
                _context.Dash.Remove(dash);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DashExists(Guid id)
        {
          return (_context.Dash?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
