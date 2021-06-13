using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HilbertsGrandHotel_KP.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HilbertsGrandHotel_KP;
using HilbertsGrandHotel_KP.Models;
using Microsoft.AspNetCore.Identity;

namespace HilbertsGrandHotel_KP.Controllers
{
    [Authorize(Roles = "sef")]
    public class SefController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<MojRegisteredUser> _userManager;

        public SefController(ApplicationDbContext context, UserManager<MojRegisteredUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Sefs
        public async Task<IActionResult> Index()
        {
            SobeController sobeController = new SobeController(_context);
            RecepcioneriController recepcioneriController = new RecepcioneriController(_context, _userManager);

            ViewData["uposlenici"] = recepcioneriController.getAll();
            ViewData["sobe"] = sobeController.getAllSobe();
            return View(await _context.Sef.ToListAsync());
        }

        // GET: Sefs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sef = await _context.Sef
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sef == null)
            {
                return NotFound();
            }

            return View(sef);
        }

        // GET: Sefs/Create
        [Authorize(Roles = "sef")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sefs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ime,prezime,email,adresaStanovanja,brojTelefona")] Sef sef)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sef);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sef);
        }

        // GET: Sefs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sef = await _context.Sef.FindAsync(id);
            if (sef == null)
            {
                return NotFound();
            }
            return View(sef);
        }

        // POST: Sefs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ime,prezime,email,adresaStanovanja,brojTelefona")] Sef sef)
        {
            if (id != sef.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sef);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SefExists(sef.ID))
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
            return View(sef);
        }

        // GET: Sefs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sef = await _context.Sef
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sef == null)
            {
                return NotFound();
            }

            return View(sef);
        }

        // POST: Sefs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sef = await _context.Sef.FindAsync(id);
            _context.Sef.Remove(sef);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SefExists(int id)
        {
            return _context.Sef.Any(e => e.ID == id);
        }
    }
}
