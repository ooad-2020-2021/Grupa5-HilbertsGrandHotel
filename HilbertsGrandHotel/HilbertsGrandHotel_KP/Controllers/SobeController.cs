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

namespace HilbertsGrandHotel_KP.Controllers
{
    public class SobeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SobeController(ApplicationDbContext context)
        {
            _context = context;
        }



        public List<Soba> getAllSobe ()
        {
            return  _context.Soba.ToList();
        }

        public List<Soba> getSortiranePoDatumu(DateTime datumPrijave, DateTime datumOdjave)
        {
            List<Soba> sveSobe = getAllSobe();
            List<Soba> sorturano = new List<Soba>();


            for (int i=0; i<sveSobe.Count; i++)
            {
                if (DateTime.Compare(sveSobe[i].datumPrijave, datumPrijave) == 0 || DateTime.Compare(sveSobe[i].datumOdjave, datumOdjave) == 0)
                    continue;
                else if(DateTime.Compare(sveSobe[i].datumPrijave, datumOdjave)>0)
                    sorturano.Add(sveSobe[i]);

                else if(DateTime.Compare(sveSobe[i].datumOdjave,datumPrijave)<0) 
                    sorturano.Add(sveSobe[i]);
            }

            return sorturano;

        }

        public async Task<IActionResult> Index()
        {
            var sveSobe = getAllSobe();
            ViewData["sveSobe"] = sveSobe;

            return View();
        }

        // GET: Sobe/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soba = await _context.Soba.FindAsync(id);
            ViewData["soba"] = soba;
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
