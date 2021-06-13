using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HilbertsGrandHotel_KP.Models
{
    public class Adapter
    {
        public String formatiraj(List<Osoblje> lista)
        {
            String s = "";
            lista.ForEach(o => s += o.ime + ", ");
            return s;
        }
    }
}
