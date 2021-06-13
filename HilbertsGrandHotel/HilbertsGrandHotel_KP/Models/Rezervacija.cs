using HilbertsGrandHotel_KP.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HilbertsGrandHotel_KP.Models
{
    public class Rezervacija
    {
        [Key]
        [Required]
        public int ID { get; set; }
        [Required]
        public MojRegisteredUser korisnik { get; set; }
        [Required]
        public Soba soba { get; set; }

        public Rezervacija() { }

        public Rezervacija(int ID, MojRegisteredUser korisnik, Soba soba)
        {
            this.ID = ID;
            this.korisnik = korisnik;
            this.soba = soba;
        }
    }
}
