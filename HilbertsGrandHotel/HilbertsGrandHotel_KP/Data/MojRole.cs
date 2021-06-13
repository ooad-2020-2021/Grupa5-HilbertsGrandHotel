using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HilbertsGrandHotel_KP.Data
{
    public class MojRole : IdentityRole
    {
        public MojRole() : base()
        {

        } 
        public MojRole(string role)
        {
            Name = role;
        }
    }
}
