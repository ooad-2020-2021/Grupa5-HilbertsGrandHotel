using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HilbertsGrandHotel_KP.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HilbertsGrandHotel_KP;
using HilbertsGrandHotel_KP.Models;

namespace HilbertsGrandHotel_KP.Controllers
{
    [Authorize]

    public class RezervacijaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<MojRegisteredUser> _userManager;
        public RezervacijaController(ApplicationDbContext context, UserManager<MojRegisteredUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        // GET: Rezervacija
        public async Task<IActionResult> Index(int? id)
        {
            var rezervacije = await _context.Rezervacija.ToListAsync();
            if(id == null)
            {
                return NotFound();
            }

            var korisnik = await _userManager.FindByNameAsync(User.Identity.Name);
            SobeController sobeController = new SobeController(_context);
            var sobe = sobeController.getAllSobe();
            var soba = sobe.Find(s => s.ID == id);
            ViewData["soba"] = soba;
            ViewData["Korisnik"] = korisnik;


            return View();
        }

        public async Task<IActionResult> Step2(int? id)
        {
            var rezervacije = await _context.Rezervacija.ToListAsync();
            if (id == null)
            {
                return NotFound();
            }

            var korisnik = await _userManager.FindByNameAsync(User.Identity.Name);
            SobeController sobeController = new SobeController(_context);
            var sobe = sobeController.getAllSobe();
            var soba = sobe.Find(s => s.ID == id);
            ViewData["soba"] = soba;
            ViewData["Korisnik"] = korisnik;

            return View();
        }

        public async Task<IActionResult> Step3(int? id)
        {

            var rezervacije = await _context.Rezervacija.ToListAsync();
            if (id == null)
            {
                return NotFound();
            }

            var korisnik = await _userManager.FindByNameAsync(User.Identity.Name);
            SobeController sobeController = new SobeController(_context);
            var sobe = sobeController.getAllSobe();
            var soba = sobe.Find(s => s.ID == id);
            ViewData["soba"] = soba;
            ViewData["Korisnik"] = korisnik;
            return View();
        }

        // GET: Rezervacija/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervacija = await _context.Rezervacija
                .FirstOrDefaultAsync(m => m.ID == id);
            if (rezervacija == null)
            {
                return NotFound();
            }

            return View(rezervacija);
        }

        // GET: Rezervacija/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rezervacija/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID")] Rezervacija rezervacija)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rezervacija);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rezervacija);
        }

        // GET: Rezervacija/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervacija = await _context.Rezervacija.FindAsync(id);
            if (rezervacija == null)
            {
                return NotFound();
            }
            return View(rezervacija);
        }

        // POST: Rezervacija/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID")] Rezervacija rezervacija)
        {
            if (id != rezervacija.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rezervacija);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RezervacijaExists(rezervacija.ID))
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
            return View(rezervacija);
        }

        // GET: Rezervacija/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervacija = await _context.Rezervacija
                .FirstOrDefaultAsync(m => m.ID == id);
            if (rezervacija == null)
            {
                return NotFound();
            }

            return View(rezervacija);
        }

        // POST: Rezervacija/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rezervacija = await _context.Rezervacija.FindAsync(id);
            _context.Rezervacija.Remove(rezervacija);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RezervacijaExists(int id)
        {
            return _context.Rezervacija.Any(e => e.ID == id);
        }

        public async Task<IActionResult> Manage()
        {
            return View(await _context.Rezervacija.ToListAsync());
        }
    }
}
