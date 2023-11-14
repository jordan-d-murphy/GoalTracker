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
    public class KaiController : Controller
    {
        private readonly GoalTrackerContext _context;

        public KaiController(GoalTrackerContext context)
        {
            _context = context;
        }

        // GET: Kai
        public async Task<IActionResult> Index()
        {
              return _context.Kai != null ? 
                          View(await _context.Kai.ToListAsync()) :
                          Problem("Entity set 'GoalTrackerContext.Kai'  is null.");
        }

        // GET: Kai/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Kai == null)
            {
                return NotFound();
            }

            var kai = await _context.Kai
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kai == null)
            {
                return NotFound();
            }

            return View(kai);
        }

        // GET: Kai/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kai/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Model,Prompt,Response")] Kai kai)
        {
            if (ModelState.IsValid)
            {
                kai.Id = Guid.NewGuid();
                _context.Add(kai);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kai);
        }

        // GET: Kai/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Kai == null)
            {
                return NotFound();
            }

            var kai = await _context.Kai.FindAsync(id);
            if (kai == null)
            {
                return NotFound();
            }
            return View(kai);
        }

        // POST: Kai/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Model,Prompt,Response")] Kai kai)
        {
            if (id != kai.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kai);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KaiExists(kai.Id))
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
            return View(kai);
        }

        // GET: Kai/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Kai == null)
            {
                return NotFound();
            }

            var kai = await _context.Kai
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kai == null)
            {
                return NotFound();
            }

            return View(kai);
        }

        // POST: Kai/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Kai == null)
            {
                return Problem("Entity set 'GoalTrackerContext.Kai'  is null.");
            }
            var kai = await _context.Kai.FindAsync(id);
            if (kai != null)
            {
                _context.Kai.Remove(kai);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KaiExists(Guid id)
        {
          return (_context.Kai?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
