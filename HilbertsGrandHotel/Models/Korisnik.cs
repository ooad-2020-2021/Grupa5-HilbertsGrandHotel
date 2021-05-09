using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekatPrvaApp.Models
{
    public class Korisnik
    {
        [Required]
        [Key]
        int ID;
        [Required]
        string ime { get; set; }
        [Required]
        string prezime { get; set; }
        [Required]
        string email { get; set; }

        public Korisnik(int ID, string ime, string prezime, string email)
        {
            this.ID = ID;
            this.ime = ime;
            this.prezime = prezime;
            this.email = email;
        }

        
    }
}
