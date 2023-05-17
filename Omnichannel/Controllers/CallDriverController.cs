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
    public class CallDriverController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CallDriverController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CallDriver
        public async Task<IActionResult> Index()
        {
            return View(await _context.CallDrivers.ToListAsync());
        }

        // GET: CallDriver/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var callDriver = await _context.CallDrivers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (callDriver == null)
            {
                return NotFound();
            }

            return View(callDriver);
        }

        // GET: CallDriver/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CallDriver/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CallDriverName")] CallDriver callDriver)
        {
            if (ModelState.IsValid)
            {
                _context.Add(callDriver);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(callDriver);
        }

        // GET: CallDriver/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var callDriver = await _context.CallDrivers.FindAsync(id);
            if (callDriver == null)
            {
                return NotFound();
            }
            return View(callDriver);
        }

        // POST: CallDriver/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CallDriverName")] CallDriver callDriver)
        {
            if (id != callDriver.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(callDriver);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CallDriverExists(callDriver.Id))
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
            return View(callDriver);
        }

        // GET: CallDriver/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var callDriver = await _context.CallDrivers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (callDriver == null)
            {
                return NotFound();
            }

            return View(callDriver);
        }

        // POST: CallDriver/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var callDriver = await _context.CallDrivers.FindAsync(id);
            if (callDriver != null)
            {
                _context.CallDrivers.Remove(callDriver);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CallDriverExists(int id)
        {
            return _context.CallDrivers.Any(e => e.Id == id);
        }
    }
}
