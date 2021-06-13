using HilbertsGrandHotel_KP.Data;
using HilbertsGrandHotel_KP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HilbertsGrandHotel_KP.Models
{
    public class Uplata
    {
        [Required]
        [Key]
        public int id {get; set;}
        [Required]
        public VrstaUplate vrstaUplate {get; set;}
        [Required]
        public MojRegisteredUser uplatioc {get; set;}
        [Required]
        public DateTime datum { get; set; }
        [Required]
        public Recepcioner odgovornoLice {get; set;}
        [Required]
        public int iznos {get; set;}

        public Uplata(int id, VrstaUplate vrstaUplate, MojRegisteredUser uplatioc, DateTime datum, Recepcioner odgovornoLice, int iznos)
        {
            this.id = id;
            this.vrstaUplate = vrstaUplate;
            this.uplatioc = uplatioc;
            this.datum = datum;
            this.odgovornoLice = odgovornoLice;
            this.iznos = iznos;
        }

        public Uplata() { }
    }
}
