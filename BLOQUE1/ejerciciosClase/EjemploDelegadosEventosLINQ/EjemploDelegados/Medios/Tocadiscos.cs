using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploDelegados.Medios
{
    internal class Tocadiscos
    {

        public Tocadiscos() { }

        public bool ProbarVinilo()
        {
            Console.WriteLine($" Por favor, ponga el vinilo en el tocadiscos.");
            Console.Write($" Indica si se escucha algo (S/N): ");
            var resultado = Console.ReadLine();
            return resultado == "S";
        }

        public string ObtenerCancionesVinilo(string codigoBarras)
        {
            // Buscar en BBDD el codigo
            // Devolver el resultado
            return $"\t La lista de canciones del vinilo con ID: {codigoBarras} está en la contraportada.";
        }
    }
}
