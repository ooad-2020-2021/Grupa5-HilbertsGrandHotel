using HilbertsGrandHotel_KP.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HilbertsGrandHotel_KP.Models
{
    public abstract class Zaposlenik
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
        [Required]
        public string adresaStanovanja { get; set; }
        [Required]
        public string brojTelefona { get; set; }

        public MojRegisteredUser aspUser { get; set; }

        public Zaposlenik() { }

        public Zaposlenik(int ID,  string ime, string prezime, string email, string adresaStanovanja, string brojTelefona, MojRegisteredUser aspUser)
        {
            this.ID = ID;
            this.ime = ime;
            this.prezime = prezime;
            this.email = email;
            this.adresaStanovanja = adresaStanovanja;
            this.brojTelefona = brojTelefona;
            this.aspUser = aspUser;
        }
    }

}
