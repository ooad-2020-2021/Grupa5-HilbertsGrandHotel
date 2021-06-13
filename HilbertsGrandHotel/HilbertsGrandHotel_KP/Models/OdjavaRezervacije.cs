using HilbertsGrandHotel_KP.Data;
using HilbertsGrandHotel_KP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HilbertsGrandHotel_KP.Models
{
    public class OdjavaRezervacije
    {
        [Key]
        [Required]
        public int id { get; set; }
        [Required]
        public MojRegisteredUser korisnik { get; set; }
        [Required]
        public Soba soba { get; set; }


        public OdjavaRezervacije() { }
        public OdjavaRezervacije(int id, MojRegisteredUser korisnik, Soba soba)
        {
            this.id = id;
            this.korisnik = korisnik;
            this.soba = soba;
        }
    }
}
