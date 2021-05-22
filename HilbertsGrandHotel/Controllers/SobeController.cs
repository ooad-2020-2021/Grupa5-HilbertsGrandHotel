using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjekatPrvaApp;
using ProjekatPrvaApp.Models;

namespace ProjekatPrvaApp.Controllers
{
    public class SobeController : Controller
    {
        private readonly HilbertContext _context;

        public SobeController(HilbertContext context)
        {
            _context = context;
        }

        // GET: Sobe
        public async Task<IActionResult> Index()
        {
            return View(await _context.Soba.ToListAsync());
        }

        // GET: Sobe/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soba = await _context.Soba
                .FirstOrDefaultAsync(m => m.ID == id);
            if (soba == null)
            {
                return NotFound();
            }

            return View(soba);
        }

        // GET: Sobe/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sobe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,stanjeSobe,zauzetostSobe,brojGostiju,brojKreveta,cijena")] Soba soba)
        {
            if (ModelState.IsValid)
            {
                _context.Add(soba);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(soba);
        }

        // GET: Sobe/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soba = await _context.Soba.FindAsync(id);
            if (soba == null)
            {
                return NotFound();
            }
            return View(soba);
        }

        // POST: Sobe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,stanjeSobe,zauzetostSobe,brojGostiju,brojKreveta,cijena")] Soba soba)
        {
            if (id != soba.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(soba);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SobaExists(soba.ID))
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
            return View(soba);
        }

        // GET: Sobe/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soba = await _context.Soba
                .FirstOrDefaultAsync(m => m.ID == id);
            if (soba == null)
            {
                return NotFound();
            }

            return View(soba);
        }

        // POST: Sobe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var soba = await _context.Soba.FindAsync(id);
            _context.Soba.Remove(soba);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SobaExists(int id)
        {
            return _context.Soba.Any(e => e.ID == id);
        }
    }
}
