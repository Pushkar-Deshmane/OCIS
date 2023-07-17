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
    public class SUSIAssistlineInteractionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SUSIAssistlineInteractionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SUSIAssistlineInteraction
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SUSIAssistlineInteractions.Include(s => s.CallDriver).Include(s => s.CallReason).Include(s => s.FurtherDetail).Include(s => s.QueryStatus).Include(s => s.SubCategory);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SUSIAssistlineInteraction/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sUSIAssistlineInteraction = await _context.SUSIAssistlineInteractions
                .Include(s => s.CallDriver)
                .Include(s => s.CallReason)
                .Include(s => s.FurtherDetail)
                .Include(s => s.QueryStatus)
                .Include(s => s.SubCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sUSIAssistlineInteraction == null)
            {
                return NotFound();
            }

            return View(sUSIAssistlineInteraction);
        }

        // GET: SUSIAssistlineInteraction/Create
        public IActionResult Create()
        {
            Guid guid = Guid.NewGuid();
            ViewData["ContactId"] = guid.ToString();
            IEnumerable<string> InfoToAgent = new string[] { "Yes", "No" };

            ViewData["CallDriverId"] = new SelectList(_context.CallDrivers, "Id", "CallDriverName");
            //ViewData["CallReasonId"] = new SelectList(_context.CallReasons, "Id", "CallReasonName");
            ViewData["FurtherDetailId"] = new SelectList(_context.FurtherDetails, "Id", "FurtherDetailName");
            ViewData["QueryStatusId"] = new SelectList(_context.QueryStatuses, "Id", "QueryStatusName");
            //ViewData["SubCategoryId"] = new SelectList(_context.SubCategories, "Id", "SubCategoryName");
            ViewData["InfoToAgent"] = new SelectList(InfoToAgent);

            var CallReasons = _context.CallReasons.ToList();
            var Subcategories = new List<SubCategory>();
            ViewData["CallReasonId"] = new SelectList(CallReasons, "Id", "CallReasonName");
            return View();
        }

        // POST: SUSIAssistlineInteraction/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ContactId,CallReasonId,SubCategoryId,FurtherDetailId,CallDriverId,InfoToAgent,QueryStatusId,Comment,CreatedDate")] SUSIAssistlineInteraction sUSIAssistlineInteraction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sUSIAssistlineInteraction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CallDriverId"] = new SelectList(_context.CallDrivers, "Id", "Id", sUSIAssistlineInteraction.CallDriverId);
            ViewData["CallReasonId"] = new SelectList(_context.CallReasons, "Id", "CallReasonName", sUSIAssistlineInteraction.CallReasonId);
            ViewData["FurtherDetailId"] = new SelectList(_context.FurtherDetails, "Id", "FurtherDetailName", sUSIAssistlineInteraction.FurtherDetailId);
            ViewData["QueryStatusId"] = new SelectList(_context.QueryStatuses, "Id", "Id", sUSIAssistlineInteraction.QueryStatusId);
            ViewData["SubCategoryId"] = new SelectList(_context.SubCategories, "Id", "SubCategoryName", sUSIAssistlineInteraction.SubCategoryId);
            return View(sUSIAssistlineInteraction);
        }

        // GET: SUSIAssistlineInteraction/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sUSIAssistlineInteraction = await _context.SUSIAssistlineInteractions.FindAsync(id);
            if (sUSIAssistlineInteraction == null)
            {
                return NotFound();
            }
            ViewData["CallDriverId"] = new SelectList(_context.CallDrivers, "Id", "Id", sUSIAssistlineInteraction.CallDriverId);
            ViewData["CallReasonId"] = new SelectList(_context.CallReasons, "Id", "CallReasonName", sUSIAssistlineInteraction.CallReasonId);
            ViewData["FurtherDetailId"] = new SelectList(_context.FurtherDetails, "Id", "FurtherDetailName", sUSIAssistlineInteraction.FurtherDetailId);
            ViewData["QueryStatusId"] = new SelectList(_context.QueryStatuses, "Id", "Id", sUSIAssistlineInteraction.QueryStatusId);
            ViewData["SubCategoryId"] = new SelectList(_context.SubCategories, "Id", "SubCategoryName", sUSIAssistlineInteraction.SubCategoryId);
            return View(sUSIAssistlineInteraction);
        }

        // POST: SUSIAssistlineInteraction/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ContactId,CallReasonId,SubCategoryId,FurtherDetailId,CallDriverId,InfoToAgent,QueryStatusId,Comment,CreatedDate")] SUSIAssistlineInteraction sUSIAssistlineInteraction)
        {
            if (id != sUSIAssistlineInteraction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sUSIAssistlineInteraction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SUSIAssistlineInteractionExists(sUSIAssistlineInteraction.Id))
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
            ViewData["CallDriverId"] = new SelectList(_context.CallDrivers, "Id", "Id", sUSIAssistlineInteraction.CallDriverId);
            ViewData["CallReasonId"] = new SelectList(_context.CallReasons, "Id", "CallReasonName", sUSIAssistlineInteraction.CallReasonId);
            ViewData["FurtherDetailId"] = new SelectList(_context.FurtherDetails, "Id", "FurtherDetailName", sUSIAssistlineInteraction.FurtherDetailId);
            ViewData["QueryStatusId"] = new SelectList(_context.QueryStatuses, "Id", "Id", sUSIAssistlineInteraction.QueryStatusId);
            ViewData["SubCategoryId"] = new SelectList(_context.SubCategories, "Id", "SubCategoryName", sUSIAssistlineInteraction.SubCategoryId);
            return View(sUSIAssistlineInteraction);
        }

        // GET: SUSIAssistlineInteraction/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sUSIAssistlineInteraction = await _context.SUSIAssistlineInteractions
                .Include(s => s.CallDriver)
                .Include(s => s.CallReason)
                .Include(s => s.FurtherDetail)
                .Include(s => s.QueryStatus)
                .Include(s => s.SubCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sUSIAssistlineInteraction == null)
            {
                return NotFound();
            }

            return View(sUSIAssistlineInteraction);
        }

        // POST: SUSIAssistlineInteraction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sUSIAssistlineInteraction = await _context.SUSIAssistlineInteractions.FindAsync(id);
            if (sUSIAssistlineInteraction != null)
            {
                _context.SUSIAssistlineInteractions.Remove(sUSIAssistlineInteraction);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SUSIAssistlineInteractionExists(int id)
        {
            return _context.SUSIAssistlineInteractions.Any(e => e.Id == id);
        }

        public JsonResult GetSubCategoryByCallReasonId(int CallReasonId)
        {
            return Json(_context.SubCategories.Where(u => u.CallReasonId == CallReasonId).ToList());            
        }
        public JsonResult GetFurtherDetailBySubCategory(int SubCategoryId)
        {
            return Json(_context.FurtherDetails.Where(u => u.SubCategoryId == SubCategoryId).ToList());
        }
        
    }
}
