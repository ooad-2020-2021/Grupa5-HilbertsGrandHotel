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
    [Authorize]
    public class OdjavaRezervacijeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OdjavaRezervacijeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OdjavaRezervacije
        public async Task<IActionResult> Index()
        {
            return View(await _context.OdjavaRezervacije.ToListAsync());
        }

        // GET: OdjavaRezervacije/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odjavaRezervacije = await _context.OdjavaRezervacije
                .FirstOrDefaultAsync(m => m.id == id);
            if (odjavaRezervacije == null)
            {
                return NotFound();
            }

            return View(odjavaRezervacije);
        }

        // GET: OdjavaRezervacije/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OdjavaRezervacije/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id")] OdjavaRezervacije odjavaRezervacije)
        {
            if (ModelState.IsValid)
            {
                _context.Add(odjavaRezervacije);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(odjavaRezervacije);
        }

        // GET: OdjavaRezervacije/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odjavaRezervacije = await _context.OdjavaRezervacije.FindAsync(id);
            if (odjavaRezervacije == null)
            {
                return NotFound();
            }
            return View(odjavaRezervacije);
        }

        // POST: OdjavaRezervacije/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id")] OdjavaRezervacije odjavaRezervacije)
        {
            if (id != odjavaRezervacije.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(odjavaRezervacije);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OdjavaRezervacijeExists(odjavaRezervacije.id))
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
            return View(odjavaRezervacije);
        }

        // GET: OdjavaRezervacije/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odjavaRezervacije = await _context.OdjavaRezervacije
                .FirstOrDefaultAsync(m => m.id == id);
            if (odjavaRezervacije == null)
            {
                return NotFound();
            }

            return View(odjavaRezervacije);
        }

        // POST: OdjavaRezervacije/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var odjavaRezervacije = await _context.OdjavaRezervacije.FindAsync(id);
            _context.OdjavaRezervacije.Remove(odjavaRezervacije);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OdjavaRezervacijeExists(int id)
        {
            return _context.OdjavaRezervacije.Any(e => e.id == id);
        }
    }
}
