using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploDelegados
{
    internal class ContenidoMedios
    {
        public delegate string InfoMedioDelegado(string id);
        public void ResultadoInfoMedioDelegado(InfoMedioDelegado infoMedioDelegado, string ID)
        {
            var resultadoPrueba = infoMedioDelegado(ID);

            Console.WriteLine(resultadoPrueba);
        }
    }
}
