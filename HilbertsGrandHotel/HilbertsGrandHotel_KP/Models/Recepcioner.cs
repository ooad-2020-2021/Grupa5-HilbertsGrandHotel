using HilbertsGrandHotel_KP.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HilbertsGrandHotel_KP.Models
{
    public class Recepcioner : Zaposlenik
    {
        public String sveSobe { get; set; }
        public Recepcioner() { }
        public Recepcioner(int ID, string ime, string prezime, string email, string adresaStanovanja, string brojTelefona, MojRegisteredUser aspUser) : base(ID, ime, prezime, email, adresaStanovanja, brojTelefona, aspUser)
        {
        }
    }
}
