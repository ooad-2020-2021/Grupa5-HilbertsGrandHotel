using HilbertsGrandHotel_KP.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HilbertsGrandHotel_KP.Models
{
    public class Osoblje : Zaposlenik
    {
        [Required]
        public String uloga { get; set; }
        public Osoblje() { }
        public Osoblje(int ID, string ime, string prezime, string email, string adresaStanovanja, string brojTelefona, MojRegisteredUser aspUser) : base(ID, ime, prezime, email, adresaStanovanja, brojTelefona, aspUser)
        {
        }
    }
}
