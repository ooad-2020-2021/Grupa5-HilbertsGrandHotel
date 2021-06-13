using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HilbertsGrandHotel_KP.Models
{
    public class Kontakt
    {
        [Required]
        [Key]
        public String imeIPrezime { get; set; }

        [Required]
        public String email { get; set; }

        [Required]
        public String predmet { get; set; }

        [Required]
        public String poruka { get; set; }

        public Kontakt(string imeIPrezime, string email, string predmet, string poruka)
        {
            this.imeIPrezime = imeIPrezime;
            this.email = email;
            this.predmet = predmet;
            this.poruka = poruka;
        }

        public Kontakt() { }

    }
}
