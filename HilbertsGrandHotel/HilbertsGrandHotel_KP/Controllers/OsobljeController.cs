using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HilbertsGrandHotel_KP.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HilbertsGrandHotel_KP;
using HilbertsGrandHotel_KP.Models;
using Microsoft.AspNetCore.Authorization;

namespace HilbertsGrandHotel_KP.Controllers
{
    [Authorize(Roles = "osoblje,recepcioner,sef")]
    public class OsobljeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OsobljeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Osoblje
        public async Task<IActionResult> Index()
        {
            return View(await _context.Osoblje.ToListAsync());
        }

        // GET: Osoblje/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var osoblje = await _context.Osoblje
                .FirstOrDefaultAsync(m => m.ID == id);
            if (osoblje == null)
            {
                return NotFound();
            }

            return View(osoblje);
        }

        // GET: Osoblje/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Osoblje/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("uloga,ID,ime,prezime,email,adresaStanovanja,brojTelefona")] Osoblje osoblje)
        {
            if (ModelState.IsValid)
            {
                _context.Add(osoblje);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(osoblje);
        }

        // GET: Osoblje/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var osoblje = await _context.Osoblje.FindAsync(id);
            if (osoblje == null)
            {
                return NotFound();
            }
            return View(osoblje);
        }

        // POST: Osoblje/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("uloga,ID,ime,prezime,email,adresaStanovanja,brojTelefona")] Osoblje osoblje)
        {
            if (id != osoblje.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(osoblje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OsobljeExists(osoblje.ID))
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
            return View(osoblje);
        }

        // GET: Osoblje/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var osoblje = await _context.Osoblje
                .FirstOrDefaultAsync(m => m.ID == id);
            if (osoblje == null)
            {
                return NotFound();
            }

            return View(osoblje);
        }

        // POST: Osoblje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var osoblje = await _context.Osoblje.FindAsync(id);
            _context.Osoblje.Remove(osoblje);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OsobljeExists(int id)
        {
            return _context.Osoblje.Any(e => e.ID == id);
        }
    }
}
