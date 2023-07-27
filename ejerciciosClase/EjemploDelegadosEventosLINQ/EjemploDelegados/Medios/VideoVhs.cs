using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploDelegados.Medios
{
    public class VideoVhs
    {
        public VideoVhs() { }
        public bool ProbarVideoVhs()
        {
            Console.WriteLine($" Por favor, ponga la cinta en el reproductor de video");
            Console.Write($" Indica si se ve algo (S/N): ");
            var result = Console.ReadLine();
            return result == "S";
        }

        public string ObtenerInfoPelicula(string codigoBarras)
        {
            // Buscar en BBDD el codigo
            // Devolver el resultado
            return $"\t La info de la película con ID: {codigoBarras} está en los créditos.";
        }

    }
}
