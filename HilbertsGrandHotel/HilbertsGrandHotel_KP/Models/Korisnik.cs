using HilbertsGrandHotel_KP.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HilbertsGrandHotel_KP.Models
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

        public MojRegisteredUser mojRegisteredUser { get; set; }

        public Korisnik()
        {

        }
        public Korisnik(int ID, string ime, string prezime, string email, MojRegisteredUser mojRegisteredUser)
        {
            this.ID = ID;
            this.ime = ime;
            this.prezime = prezime;
            this.email = email;
            this.mojRegisteredUser = mojRegisteredUser;
        }

        
    }
}
