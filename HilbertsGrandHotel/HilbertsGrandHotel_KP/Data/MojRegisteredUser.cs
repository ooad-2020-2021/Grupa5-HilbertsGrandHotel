using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HilbertsGrandHotel_KP.Data
{
    public class MojRegisteredUser : IdentityUser
    {
        public string firstName { get; set; }
        public string lastName { get; set; }

    }
}
