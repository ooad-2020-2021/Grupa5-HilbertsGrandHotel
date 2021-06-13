using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HilbertsGrandHotel_KP.Data;
using HilbertsGrandHotel_KP.Models;
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
    public class KorisnikController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<MojRegisteredUser> _userManager;
        public KorisnikController(ApplicationDbContext context, UserManager<MojRegisteredUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Korisnici
        public async Task<IActionResult> Index()
        {
            
            var rezervacije = await _context.Rezervacija.ToListAsync();
            var korisnik = await _userManager.FindByNameAsync(User.Identity.Name);
            if (korisnik != null)
            {
                    ViewData["Korisnik"] = korisnik;
            }
            return View();
        }

        // GET: Korisnici/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var korisnik = await _context.Korisnik
                .FirstOrDefaultAsync(m => m.ID == id);
            if (korisnik == null)
            {
                return NotFound();
            }

            return View(korisnik);
        }

        // GET: Korisnici/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Korisnici/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ime,prezime,email")] Korisnik korisnik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(korisnik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(korisnik);
        }

        // GET: Korisnici/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var korisnik = await _context.Korisnik.FindAsync(id);
            if (korisnik == null)
            {
                return NotFound();
            }
            return View(korisnik);
        }

        // POST: Korisnici/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ime,prezime,email")] Korisnik korisnik)
        {
            if (id != korisnik.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(korisnik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KorisnikExists(korisnik.ID))
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
            return View(korisnik);
        }

        // GET: Korisnici/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var korisnik = await _context.Korisnik
                .FirstOrDefaultAsync(m => m.ID == id);
            if (korisnik == null)
            {
                return NotFound();
            }

            return View(korisnik);
        }

        // POST: Korisnici/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var korisnik = await _context.Korisnik.FindAsync(id);
            _context.Korisnik.Remove(korisnik);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KorisnikExists(int id)
        {
            return _context.Korisnik.Any(e => e.ID == id);
        }

        public async Task<IActionResult> Dodaj(string id, [Bind("ime, tekst")] Recenzija recenzija)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine("ime i prezime " + recenzija.ime + " i poruka je " + recenzija.tekst);
                //await Services.EmailSender.PrimiEmail(korisnik.email, kontakt.predmet, kontakt.poruka, kontakt.imeIPrezime);
                recenzija.datum = DateTime.Now;
                recenzija.likes = 0;
                _context.Add(recenzija);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Index");
        }
    }
}
