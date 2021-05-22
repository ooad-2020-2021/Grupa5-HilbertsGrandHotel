using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekatPrvaApp.Models
{
    public class Korisnik
    {
        [Key]
        [Required]
        public int ID { get; set; }
        [Required]
        public string ime { get; set; }
        [Required]
        public string prezime { get; set; }
        [Required]
        public string email { get; set; }

        public Korisnik()
        {

        }
        public Korisnik(int ID, string ime, string prezime, string email)
        {
            this.ID = ID;
            this.ime = ime;
            this.prezime = prezime;
            this.email = email;
        }

        
    }
}
