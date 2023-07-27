using EjemploDelegados.Medios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploDelegados
{
    public class InventarioMedios
    {
        public delegate bool ProbarMediosDelegado();
        public void ResultadoProbarMedios(ProbarMediosDelegado probarMediosDelegado) 
        {
            // 1-. Recibir el medio a probar
            // 2-. Probar el medio
            // 3-. Si el medio se ha podido reproducir, indicar como archivarlo

            var resultadoPrueba = probarMediosDelegado();

            if (resultadoPrueba) 
            {
                Console.WriteLine($" El medio funciona, hay que agregarlo al inventario.");
            } 
            else 
            { 
                Console.WriteLine($" El medio no funciona, hay que destruirlo."); 
            }
        }
    }
}
