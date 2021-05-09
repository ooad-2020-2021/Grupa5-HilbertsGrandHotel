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
        int ID { get; set; }
        StanjeSobe stanjeSobe { get; set; }
        [Required]
        bool zauzetostSobe { get; set; }
        [Required]
        int brojGostiju { get; set; }
        [Required]
        int brojKreveta { get; set; }
        [Required]
        double cijena { get; set; }
        [Required]
        Korisnik korisnik { get; set; }

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
