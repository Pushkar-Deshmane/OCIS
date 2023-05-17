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
    public class QueryStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QueryStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: QueryStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.QueryStatuses.ToListAsync());
        }

        // GET: QueryStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var queryStatus = await _context.QueryStatuses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (queryStatus == null)
            {
                return NotFound();
            }

            return View(queryStatus);
        }

        // GET: QueryStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: QueryStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,QueryStatusName")] QueryStatus queryStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(queryStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(queryStatus);
        }

        // GET: QueryStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var queryStatus = await _context.QueryStatuses.FindAsync(id);
            if (queryStatus == null)
            {
                return NotFound();
            }
            return View(queryStatus);
        }

        // POST: QueryStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,QueryStatusName")] QueryStatus queryStatus)
        {
            if (id != queryStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(queryStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QueryStatusExists(queryStatus.Id))
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
            return View(queryStatus);
        }

        // GET: QueryStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var queryStatus = await _context.QueryStatuses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (queryStatus == null)
            {
                return NotFound();
            }

            return View(queryStatus);
        }

        // POST: QueryStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var queryStatus = await _context.QueryStatuses.FindAsync(id);
            if (queryStatus != null)
            {
                _context.QueryStatuses.Remove(queryStatus);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QueryStatusExists(int id)
        {
            return _context.QueryStatuses.Any(e => e.Id == id);
        }
    }
}
