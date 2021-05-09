using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekatPrvaApp.Models
{
    public class Sef : Zaposlenik
    {
        [NotMapped]
        List<Osoblje> listaOsoblja { get; set; }
        public Sef(int ID, string ime, string prezime, string email, string adresaStanovanja, string brojTelefona) : base(ID, ime, prezime, email, adresaStanovanja, brojTelefona){}
    }
}
