using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HilbertsGrandHotel_KP.Data;
using HilbertsGrandHotel_KP.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HilbertsGrandHotel_KP;
using HilbertsGrandHotel_KP.Models;

namespace HilbertsGrandHotel_KP.Controllers
{
    [Authorize(Roles = "recepcioner,sef")]
    public class RecepcioneriController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<MojRegisteredUser> _userManager;

        public RecepcioneriController(ApplicationDbContext context, UserManager<MojRegisteredUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Recepcioneri
        public async Task<IActionResult> Index()
        {
            SobeController sobeController = new SobeController(_context);
            ViewData["sobe"] = sobeController.getAllSobe();
            return View(await _context.Recepcioner.ToListAsync());
        }

        [Authorize(Roles = "sef")]
        public async Task<IActionResult> Manage()
        {
            return View(await _context.Recepcioner.ToListAsync());
        }

        // GET: Recepcioneri/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recepcioner = await _context.Recepcioner
                .FirstOrDefaultAsync(m => m.ID == id);
            if (recepcioner == null)
            {
                return NotFound();
            }

            return View(recepcioner);
        }

        // GET: Recepcioneri/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recepcioneri/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("sveSobe,ID,ime,prezime,email,adresaStanovanja,brojTelefona")] Recepcioner recepcioner)
        {
            if (ModelState.IsValid)
            {
                
                String password = CreatePassword();
                var user = new MojRegisteredUser { firstName = recepcioner.ime, lastName = recepcioner.prezime, UserName = recepcioner.email, Email = recepcioner.email };
                var result = await _userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    Console.WriteLine("Uspjesno");
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var resultConfirma = await _userManager.ConfirmEmailAsync(user, code);
                    var aspUserID = await _userManager.FindByIdAsync(user.Id);
                    if(aspUserID != null)
                    {
                        Console.WriteLine("User id: " + user.Id + ", a ime je " + user.UserName);
                        recepcioner.aspUser = aspUserID;
                        Console.WriteLine("Recepcioner asp id: " + recepcioner.aspUser.Id);
                    }
                    _context.Add(recepcioner);
                    await _context.SaveChangesAsync();
                }
                    await EmailSender.PosaljiEmail(recepcioner.email, "Sifra za recepcionera", "Vas password je " + password, "Sef Hilberta");
                return RedirectToAction(nameof(Index));
            }
            return View(recepcioner);
        }

        private string CreatePassword(PasswordOptions opts = null)
        {
            if (opts == null) opts = new PasswordOptions()
            {
                RequiredLength = 8,
                RequiredUniqueChars = 4,
                RequireDigit = true,
                RequireLowercase = true,
                RequireNonAlphanumeric = true,
                RequireUppercase = true
            };

            string[] randomChars = new[] {
            "ABCDEFGHJKLMNOPQRSTUVWXYZ",    // uppercase 
            "abcdefghijkmnopqrstuvwxyz",    // lowercase
            "0123456789",                   // digits
            "!@$?_-"                        // non-alphanumeric
        };

            Random rand = new Random(Environment.TickCount);
            List<char> chars = new List<char>();

            if (opts.RequireUppercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[0][rand.Next(0, randomChars[0].Length)]);

            if (opts.RequireLowercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[1][rand.Next(0, randomChars[1].Length)]);

            if (opts.RequireDigit)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[2][rand.Next(0, randomChars[2].Length)]);

            if (opts.RequireNonAlphanumeric)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[3][rand.Next(0, randomChars[3].Length)]);

            for (int i = chars.Count; i < opts.RequiredLength
                || chars.Distinct().Count() < opts.RequiredUniqueChars; i++)
            {
                string rcs = randomChars[rand.Next(0, randomChars.Length)];
                chars.Insert(rand.Next(0, chars.Count),
                    rcs[rand.Next(0, rcs.Length)]);
            }

            return new string(chars.ToArray());
        }
        // GET: Recepcioneri/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recepcioner = await _context.Recepcioner.FindAsync(id);
            if (recepcioner == null)
            {
                return NotFound();
            }
            return View(recepcioner);
        }

        // POST: Recepcioneri/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("sveSobe,ID,ime,prezime,email,adresaStanovanja,brojTelefona")] Recepcioner recepcioner)
        {
            if (id != recepcioner.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recepcioner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecepcionerExists(recepcioner.ID))
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
            return View(recepcioner);
        }

        // GET: Recepcioneri/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recepcioner = await _context.Recepcioner
                .FirstOrDefaultAsync(m => m.ID == id);
            if (recepcioner == null)
            {
                return NotFound();
            }

            return View(recepcioner);
        }

        // POST: Recepcioneri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recepcioner = await _context.Recepcioner.FindAsync(id);
            _context.Recepcioner.Remove(recepcioner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecepcionerExists(int id)
        {
            return _context.Recepcioner.Any(e => e.ID == id);
        }

        public List<Recepcioner> getAll()
        {
            return _context.Recepcioner.ToList();
        }
    }
}
