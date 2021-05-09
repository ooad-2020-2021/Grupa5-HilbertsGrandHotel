using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekatPrvaApp.Models
{
    public abstract class Zaposlenik
    {
        [Key]
        [Required]
        int ID;
        [Required]
        string ime { get; set; }
        [Required]
        string prezime { get; set; }
        [Required]
        string email { get; set; }
        [Required]
        string adresaStanovanja { get; set; }
        [Required]
        string brojTelefona { get; set; }

        protected Zaposlenik(int ID,  string ime, string prezime, string email, string adresaStanovanja, string brojTelefona)
        {
            this.ID = ID;
            this.ime = ime;
            this.prezime = prezime;
            this.email = email;
            this.adresaStanovanja = adresaStanovanja;
            this.brojTelefona = brojTelefona;
        }
    }

}
