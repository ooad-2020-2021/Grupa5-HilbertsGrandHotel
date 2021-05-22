using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekatPrvaApp.Models
{
    public class Soba
    {
        [Key]
        [Required]
        public int ID { get; set; }
        public StanjeSobe stanjeSobe { get; set; }
        [Required]
        public bool zauzetostSobe { get; set; }
        [Required]
        public int brojGostiju { get; set; }
        [Required]
        public int brojKreveta { get; set; }
        [Required]
        public double cijena { get; set; }

        public Korisnik korisnik { get; set; }

        public Soba() { }

       

        public Soba(int ID, StanjeSobe stanjeSobe, bool zauzetostSobe, int brojGostiju, int brojKreveta, double cijena, Korisnik korisnik)
        {
            this.ID = ID;
            this.stanjeSobe = stanjeSobe;
            this.zauzetostSobe = zauzetostSobe;
            this.brojGostiju = brojGostiju;
            this.brojKreveta = brojKreveta;
            this.cijena = cijena;
            this.korisnik = korisnik;
        }
    }
}
