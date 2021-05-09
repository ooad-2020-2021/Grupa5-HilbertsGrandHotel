using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekatPrvaApp.Models
{
    public class Rezervacija
    {
        [Key]
        [Required]
        int ID;
        [Required]
        Korisnik korisnik { get; set; }
        [Required]
        Soba soba { get; set; }

        public Rezervacija(int ID, Korisnik korisnik, Soba soba)
        {
            this.ID = ID;
            this.korisnik = korisnik;
            this.soba = soba;
        }
    }
}
