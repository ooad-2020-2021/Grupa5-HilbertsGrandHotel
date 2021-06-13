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
    [Authorize(Roles = "recepcioner,sef")]
    public class NaplataRecepcionerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NaplataRecepcionerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NaplataRecepcioners
        public async Task<IActionResult> Index()
        {
            return View(await _context.NaplataRecepcioner.ToListAsync());
        }

        // GET: NaplataRecepcioners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var naplataRecepcioner = await _context.NaplataRecepcioner
                .FirstOrDefaultAsync(m => m.id == id);
            if (naplataRecepcioner == null)
            {
                return NotFound();
            }

            return View(naplataRecepcioner);
        }

        // GET: NaplataRecepcioners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NaplataRecepcioners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,iznos")] NaplataRecepcioner naplataRecepcioner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(naplataRecepcioner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(naplataRecepcioner);
        }

        // GET: NaplataRecepcioners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var naplataRecepcioner = await _context.NaplataRecepcioner.FindAsync(id);
            if (naplataRecepcioner == null)
            {
                return NotFound();
            }
            return View(naplataRecepcioner);
        }

        // POST: NaplataRecepcioners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,iznos")] NaplataRecepcioner naplataRecepcioner)
        {
            if (id != naplataRecepcioner.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(naplataRecepcioner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NaplataRecepcionerExists(naplataRecepcioner.id))
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
            return View(naplataRecepcioner);
        }

        // GET: NaplataRecepcioners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var naplataRecepcioner = await _context.NaplataRecepcioner
                .FirstOrDefaultAsync(m => m.id == id);
            if (naplataRecepcioner == null)
            {
                return NotFound();
            }

            return View(naplataRecepcioner);
        }

        // POST: NaplataRecepcioners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var naplataRecepcioner = await _context.NaplataRecepcioner.FindAsync(id);
            _context.NaplataRecepcioner.Remove(naplataRecepcioner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NaplataRecepcionerExists(int id)
        {
            return _context.NaplataRecepcioner.Any(e => e.id == id);
        }
    }
}
