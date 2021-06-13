using HilbertsGrandHotel_KP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HilbertsGrandHotel_KP.Models
{
    public class Recenzija
    {
        [Key]
        [Required]
        public int id { get; set; }
        [Required]
        public String ime { get; set; }
        [Required]
        public DateTime datum { get; set; }
        [Required]
        public String tekst { get; set; }
        [Required]
        public int likes { get; set; }
        public Soba soba { get; set; }

        public Recenzija(int id, string ime, DateTime datum, string tekst, int likes, Soba soba)
        {
            this.id = id;
            this.ime = ime;
            this.datum = datum;
            this.tekst = tekst;
            this.soba = soba;
            this.likes = likes;
        }

        public Recenzija() { }
    }
}
