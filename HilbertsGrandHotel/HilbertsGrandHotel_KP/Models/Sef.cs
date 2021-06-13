using HilbertsGrandHotel_KP.Data;
using HilbertsGrandHotel_KP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HilbertsGrandHotel_KP.Models
{
    public class Sef : Zaposlenik, SefInterface
    {
        [Required]
        public String listaOsoblja { get; set; }
      
        [Required]
        private Sef instance { get; set; }
        private Sef() { }
        public Sef(int ID, string ime, string prezime, string email, string adresaStanovanja, string brojTelefona, MojRegisteredUser aspUser) : base(ID, ime, prezime, email, adresaStanovanja, brojTelefona, aspUser) { }

        public Sef getInstance()
        {
            if(instance == null)
            {
                instance = new Sef();
            }
            return instance;
        }

        public string ispisi()
        {
            return listaOsoblja.ToString();
        }
    }
}
