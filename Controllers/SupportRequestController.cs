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
    public class SupportRequestController : Controller
    {
        private readonly GoalTrackerContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public SupportRequestController(GoalTrackerContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: SupportRequest
        public async Task<IActionResult> Index()
        {
            var supportRequests = _context.SupportRequest.Include(t => t.Parent).Include(t => t.CreatedBy);
            return View(await supportRequests.ToListAsync());
        }

        // GET: SupportRequest/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.SupportRequest == null)
            {
                return NotFound();
            }

            var supportRequest = await _context.SupportRequest
                .FirstOrDefaultAsync(m => m.Id == id);
            if (supportRequest == null)
            {
                return NotFound();
            }

            return View(supportRequest);
        }

        // GET: SupportRequest/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SupportRequest/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ParentId,Title,Description,CreatedDate,StartedDate,TargetDate,CompletedDate,Completed,Favorited,Category,Icon,Color")] SupportRequest supportRequest)
        {
            var user = _userManager.GetUserAsync(User).Result;

            if (user is not null)
            {
                if (ModelState.IsValid)
                {
                    supportRequest.Id = Guid.NewGuid();
                    supportRequest.CreatedBy = user;
                    supportRequest.CreatedDate = DateTime.Now;
                    _context.Add(supportRequest);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(supportRequest);
        }

        // GET: SupportRequest/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.SupportRequest == null)
            {
                return NotFound();
            }

            var supportRequest = await _context.SupportRequest.FindAsync(id);
            if (supportRequest == null)
            {
                return NotFound();
            }
            return View(supportRequest);
        }

        // POST: SupportRequest/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,ParentId,Title,Description,CreatedDate,StartedDate,TargetDate,CompletedDate,Completed,Favorited,Category,Icon,Color")] SupportRequest supportRequest)
        {
            if (id != supportRequest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supportRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupportRequestExists(supportRequest.Id))
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
            return View(supportRequest);
        }

        // GET: SupportRequest/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.SupportRequest == null)
            {
                return NotFound();
            }

            var supportRequest = await _context.SupportRequest
                .FirstOrDefaultAsync(m => m.Id == id);
            if (supportRequest == null)
            {
                return NotFound();
            }

            return View(supportRequest);
        }

        // POST: SupportRequest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.SupportRequest == null)
            {
                return Problem("Entity set 'GoalTrackerContext.SupportRequest'  is null.");
            }
            var supportRequest = await _context.SupportRequest.FindAsync(id);
            if (supportRequest != null)
            {
                _context.SupportRequest.Remove(supportRequest);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupportRequestExists(Guid id)
        {
          return (_context.SupportRequest?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
