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
    public class FileAttachmentController : Controller
    {
        private readonly GoalTrackerContext _context;

        public FileAttachmentController(GoalTrackerContext context)
        {
            _context = context;
        }

        // GET: FileAttachment
        public async Task<IActionResult> Index()
        {
              return _context.FileAttachment != null ? 
                          View(await _context.FileAttachment.ToListAsync()) :
                          Problem("Entity set 'GoalTrackerContext.FileAttachment'  is null.");
        }

        // GET: FileAttachment/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.FileAttachment == null)
            {
                return NotFound();
            }

            var fileAttachment = await _context.FileAttachment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fileAttachment == null)
            {
                return NotFound();
            }

            return View(fileAttachment);
        }

        // GET: FileAttachment/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FileAttachment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TrackingRecordId,FileName,FileExtension,Url,UploadedDate")] FileAttachment fileAttachment)
        {
            if (ModelState.IsValid)
            {
                fileAttachment.Id = Guid.NewGuid();
                _context.Add(fileAttachment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fileAttachment);
        }

        // GET: FileAttachment/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.FileAttachment == null)
            {
                return NotFound();
            }

            var fileAttachment = await _context.FileAttachment.FindAsync(id);
            if (fileAttachment == null)
            {
                return NotFound();
            }
            return View(fileAttachment);
        }

        // POST: FileAttachment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,TrackingRecordId,FileName,FileExtension,Url,UploadedDate")] FileAttachment fileAttachment)
        {
            if (id != fileAttachment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fileAttachment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FileAttachmentExists(fileAttachment.Id))
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
            return View(fileAttachment);
        }

        // GET: FileAttachment/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.FileAttachment == null)
            {
                return NotFound();
            }

            var fileAttachment = await _context.FileAttachment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fileAttachment == null)
            {
                return NotFound();
            }

            return View(fileAttachment);
        }

        // POST: FileAttachment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.FileAttachment == null)
            {
                return Problem("Entity set 'GoalTrackerContext.FileAttachment'  is null.");
            }
            var fileAttachment = await _context.FileAttachment.FindAsync(id);
            if (fileAttachment != null)
            {
                _context.FileAttachment.Remove(fileAttachment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FileAttachmentExists(Guid id)
        {
          return (_context.FileAttachment?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
