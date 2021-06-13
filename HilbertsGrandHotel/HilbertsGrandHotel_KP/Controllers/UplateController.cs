using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HilbertsGrandHotel_KP.Data;
using HilbertsGrandHotel_KP.Models;
using Microsoft.AspNetCore.Authorization;

namespace HilbertsGrandHotel_KP.Controllers
{
    [Authorize(Roles = "sef")]
    public class UplateController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UplateController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Uplate
        public async Task<IActionResult> Index()
        {
            return View(await _context.Uplata.ToListAsync());
        }

        // GET: Uplate/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uplata = await _context.Uplata
                .FirstOrDefaultAsync(m => m.id == id);
            if (uplata == null)
            {
                return NotFound();
            }

            return View(uplata);
        }

        // GET: Uplate/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Uplate/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,vrstaUplate,datum,iznos")] Uplata uplata)
        {
            if (ModelState.IsValid)
            {
                _context.Add(uplata);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(uplata);
        }

        // GET: Uplate/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uplata = await _context.Uplata.FindAsync(id);
            if (uplata == null)
            {
                return NotFound();
            }
            return View(uplata);
        }

        // POST: Uplate/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,vrstaUplate,datum,iznos")] Uplata uplata)
        {
            if (id != uplata.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uplata);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UplataExists(uplata.id))
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
            return View(uplata);
        }

        // GET: Uplate/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uplata = await _context.Uplata
                .FirstOrDefaultAsync(m => m.id == id);
            if (uplata == null)
            {
                return NotFound();
            }

            return View(uplata);
        }

        // POST: Uplate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var uplata = await _context.Uplata.FindAsync(id);
            _context.Uplata.Remove(uplata);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UplataExists(int id)
        {
            return _context.Uplata.Any(e => e.id == id);
        }
    }
}
