using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMonedaNombre
{
    public class FormatoJsonN
    {

        public class Root
        {
            public Monedanombre Monedanombre { get; set; }
        }

        public class Monedanombre
        {
            public string prefijo { get; set; }
            public string description { get; set; }
        }

    }
}
