using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Omnichannel.Data;
using Omnichannel.Models;

namespace Omnichannel.Controllers
{
    public class FurtherDetailController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FurtherDetailController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FurtherDetail
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.FurtherDetails.Include(f => f.SubCategory);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FurtherDetail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var furtherDetail = await _context.FurtherDetails
                .Include(f => f.SubCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (furtherDetail == null)
            {
                return NotFound();
            }

            return View(furtherDetail);
        }

        // GET: FurtherDetail/Create
        public IActionResult Create()
        {
            ViewData["SubCategoryId"] = new SelectList(_context.SubCategories, "Id", "SubCategoryName");
            return View();
        }

        // POST: FurtherDetail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FurtherDetailName,SubCategoryId")] FurtherDetail furtherDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(furtherDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubCategoryId"] = new SelectList(_context.SubCategories, "Id", "SubCategoryName", furtherDetail.SubCategoryId);
            return View(furtherDetail);
        }

        // GET: FurtherDetail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var furtherDetail = await _context.FurtherDetails.FindAsync(id);
            if (furtherDetail == null)
            {
                return NotFound();
            }
            ViewData["SubCategoryId"] = new SelectList(_context.SubCategories, "Id", "SubCategoryName", furtherDetail.SubCategoryId);
            return View(furtherDetail);
        }

        // POST: FurtherDetail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FurtherDetailName,SubCategoryId")] FurtherDetail furtherDetail)
        {
            if (id != furtherDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(furtherDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FurtherDetailExists(furtherDetail.Id))
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
            ViewData["SubCategoryId"] = new SelectList(_context.SubCategories, "Id", "SubCategoryName", furtherDetail.SubCategoryId);
            return View(furtherDetail);
        }

        // GET: FurtherDetail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var furtherDetail = await _context.FurtherDetails
                .Include(f => f.SubCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (furtherDetail == null)
            {
                return NotFound();
            }

            return View(furtherDetail);
        }

        // POST: FurtherDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var furtherDetail = await _context.FurtherDetails.FindAsync(id);
            if (furtherDetail != null)
            {
                _context.FurtherDetails.Remove(furtherDetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FurtherDetailExists(int id)
        {
            return _context.FurtherDetails.Any(e => e.Id == id);
        }
    }
}
