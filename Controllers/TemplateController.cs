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
    public class TemplateController : Controller
    {
        private readonly GoalTrackerContext _context;

        public TemplateController(GoalTrackerContext context)
        {
            _context = context;
        }

        // GET: Template
        public async Task<IActionResult> Index()
        {
            var goalTrackerContext = _context.Template.Include(t => t.Parent);
            return View(await goalTrackerContext.ToListAsync());
        }

        // GET: Template/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Template == null)
            {
                return NotFound();
            }

            var template = await _context.Template
                .Include(t => t.Parent)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (template == null)
            {
                return NotFound();
            }

            return View(template);
        }

        // GET: Template/Create
        public IActionResult Create()
        {
            ViewData["ParentId"] = new SelectList(_context.Set<TrackingRecord>(), "Id", "Discriminator");
            return View();
        }

        // POST: Template/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,JSONData,Id,ParentId,Title,Description,CreatedDate,StartedDate,TargetDate,CompletedDate,Completed,Favorited,Category,Icon,Color")] Template template)
        {
            if (ModelState.IsValid)
            {
                template.Id = Guid.NewGuid();
                _context.Add(template);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ParentId"] = new SelectList(_context.Set<TrackingRecord>(), "Id", "Discriminator", template.ParentId);
            return View(template);
        }

        // GET: Template/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Template == null)
            {
                return NotFound();
            }

            var template = await _context.Template.FindAsync(id);
            if (template == null)
            {
                return NotFound();
            }
            ViewData["ParentId"] = new SelectList(_context.Set<TrackingRecord>(), "Id", "Discriminator", template.ParentId);
            return View(template);
        }

        // POST: Template/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,JSONData,Id,ParentId,Title,Description,CreatedDate,StartedDate,TargetDate,CompletedDate,Completed,Favorited,Category,Icon,Color")] Template template)
        {
            if (id != template.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(template);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TemplateExists(template.Id))
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
            ViewData["ParentId"] = new SelectList(_context.Set<TrackingRecord>(), "Id", "Discriminator", template.ParentId);
            return View(template);
        }

        // GET: Template/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Template == null)
            {
                return NotFound();
            }

            var template = await _context.Template
                .Include(t => t.Parent)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (template == null)
            {
                return NotFound();
            }

            return View(template);
        }

        // POST: Template/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Template == null)
            {
                return Problem("Entity set 'GoalTrackerContext.Template'  is null.");
            }
            var template = await _context.Template.FindAsync(id);
            if (template != null)
            {
                _context.Template.Remove(template);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TemplateExists(Guid id)
        {
          return (_context.Template?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
