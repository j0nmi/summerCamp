using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntregaUno.Clases
{
    internal class Historial
    {
        public string codigo { get; set; }
        public string monedaOrigen { get; set; }
        public string monedaDestino { get; set; }
        public float factor { get; set; }
        public double cantidad { get; set; }
        public string fechaConversion { get; set; }
    }

}
