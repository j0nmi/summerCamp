using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace explicacionHerencia
{
    public class Empresa
    {
        public Empresa(string nombre, int codigoPostal)
        {
            Nombre = nombre;
            CodigoPostal = codigoPostal;
        }

        public string Nombre { get; set; }
        public int CodigoPostal { get; set; }

    }
}