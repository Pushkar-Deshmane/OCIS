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
    public class CallReasonController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CallReasonController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CallReason
        public async Task<IActionResult> Index()
        {
            return View(await _context.CallReasons.ToListAsync());
        }

        // GET: CallReason/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var callReason = await _context.CallReasons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (callReason == null)
            {
                return NotFound();
            }

            return View(callReason);
        }

        // GET: CallReason/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CallReason/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CallReasonName")] CallReason callReason)
        {
            if (ModelState.IsValid)
            {
                _context.Add(callReason);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(callReason);
        }

        // GET: CallReason/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var callReason = await _context.CallReasons.FindAsync(id);
            if (callReason == null)
            {
                return NotFound();
            }
            return View(callReason);
        }

        // POST: CallReason/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CallReasonName")] CallReason callReason)
        {
            if (id != callReason.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(callReason);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CallReasonExists(callReason.Id))
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
            return View(callReason);
        }

        // GET: CallReason/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var callReason = await _context.CallReasons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (callReason == null)
            {
                return NotFound();
            }

            return View(callReason);
        }

        // POST: CallReason/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var callReason = await _context.CallReasons.FindAsync(id);
            if (callReason != null)
            {
                _context.CallReasons.Remove(callReason);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CallReasonExists(int id)
        {
            return _context.CallReasons.Any(e => e.Id == id);
        }
    }
}
