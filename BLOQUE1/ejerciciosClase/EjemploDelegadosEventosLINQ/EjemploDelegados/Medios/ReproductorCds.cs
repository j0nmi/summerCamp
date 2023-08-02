using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploDelegados.Medios
{
    internal class ReproductorCds
    {
        public ReproductorCds() { }

        public bool ProbarCds()
        {
            Console.WriteLine("Por favor, ponga el cd en el reproductor");
            Console.WriteLine("Pulsa el botón de reproducción");
            Console.Write($" Indica si se escucha algo (S/N): ");
            var result = Console.ReadLine();
            return result == "S";
        }

        public string ObtenerCancionesCd(string codigoBarras)
        {
            return $"\t La lista de canciones del cd con ID: {codigoBarras} estan en la portada.";
        }
    }
}
