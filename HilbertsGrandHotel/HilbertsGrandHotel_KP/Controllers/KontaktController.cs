using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HilbertsGrandHotel_KP.Data;
using HilbertsGrandHotel_KP.Models;
using MimeKit;

namespace HilbertsGrandHotel_KP.Controllers
{
    public class KontaktController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KontaktController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Kontakt
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: Kontakt/Details/5
        public async Task<IActionResult> Details(string id)
        {

            return View();
        }

        // GET: Kontakt/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kontakt/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("imeIPrezime,email,predmet,poruka")] Kontakt kontakt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kontakt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kontakt);
        }

        // GET: Kontakt/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            
            return View();
        }

        // POST: Kontakt/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("imeIPrezime,email,predmet,poruka")] Kontakt kontakt)
        {
            return View();
        }

        // GET: Kontakt/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
          

            return View();
        }

        //// POST: Kontakt/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(string id)
        //{
        //    var kontakt = await _context.Kontakt.FindAsync(id);
        //    _context.Kontakt.Remove(kontakt);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool KontaktExists(string id)
        //{
        //    return _context.Kontakt.Any(e => e.imeIPrezime == id);
        //}

        public async Task<IActionResult> Posalji(string id, [Bind("imeIPrezime,email,predmet,poruka")] Kontakt kontakt)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine("ime i prezime " + kontakt.imeIPrezime + " email je " + kontakt.email + " i poruka je " + kontakt.poruka);
                await Services.EmailSender.PrimiEmail(kontakt.email, kontakt.predmet, kontakt.poruka, kontakt.imeIPrezime);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Index");
        }
    }
}
