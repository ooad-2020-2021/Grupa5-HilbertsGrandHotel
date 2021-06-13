using HilbertsGrandHotel_KP.Data;
using HilbertsGrandHotel_KP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HilbertsGrandHotel_KP.Models
{
    public class NaplataRecepcioner
    {
        [Key]
        [Required]
        public int id { get; set; }
        [Required]
        public Double iznos { get; set; }
        [Required]
        public MojRegisteredUser korisnik{ get; set; }
      
        [Required]
        public Soba soba { get; set; }

        public NaplataRecepcioner()
        {

        }

        public NaplataRecepcioner(int id, double iznos, MojRegisteredUser korisnik, Soba soba)
        {
            this.id = id;
            this.iznos = iznos;
            this.korisnik = korisnik;
            this.soba = soba;
        }
    }
}
