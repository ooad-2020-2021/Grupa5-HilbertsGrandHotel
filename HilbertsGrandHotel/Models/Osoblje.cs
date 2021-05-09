using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekatPrvaApp.Models
{
    public class Osoblje : Zaposlenik
    {
        [Required]
        String uloga { get; set; }
        public Osoblje(int ID, string ime, string prezime, string email, string adresaStanovanja, string brojTelefona) : base(ID, ime, prezime, email, adresaStanovanja, brojTelefona)
        {
        }
    }
}
