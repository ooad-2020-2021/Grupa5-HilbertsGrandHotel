using HilbertsGrandHotel_KP.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HilbertsGrandHotel_KP.Models
{
    public class Soba
    {
        [Key]
        [Required]
        public int ID { get; set; }
        public StanjeSobe stanjeSobe { get; set; }
      
        public DateTime datumPrijave { get; set; }

        public DateTime datumOdjave { get; set; }

        [Required]
        public bool zauzetostSobe { get; set; }
        [Required]
        public int brojGostiju { get; set; }
        [Required]
        public int brojKreveta { get; set; }
        [Required]
        public double cijena { get; set; }

        public MojRegisteredUser korisnik { get; set; }

        public Soba() { }



        public Soba(int ID, StanjeSobe stanjeSobe, DateTime datumPrijave, DateTime datumOdjave, bool zauzetostSobe, int brojGostiju, int brojKreveta, double cijena, MojRegisteredUser korisnik)
        {
            this.ID = ID;
            this.stanjeSobe = stanjeSobe;
            this.datumPrijave = datumPrijave;
            this.datumOdjave = datumOdjave;
            this.zauzetostSobe = zauzetostSobe;
            this.brojGostiju = brojGostiju;
            this.brojKreveta = brojKreveta;
            this.cijena = cijena;
            this.korisnik = korisnik;
        }

        

     /*   public List<Soba> sortirajPoDatumu(DateTime datumDolaska, DateTime datumOdjave)
        {
           
        }*/
    }
}
