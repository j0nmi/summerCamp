using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace explicacionHerencia
{
    public partial class Empleado
    {
        public string Nombre { get; set; }

        public Empleado(string nombre)
        {
            Nombre = nombre;
        }

        // Si creamos el ctor con parámetros, creamos el predeterminado
        // public Empleado()
        // {
        //     Nombre = string.Empty;
        //}

        protected double diasVacaciones;

        // Cambiamos el comportamiento del ToString() para que muestre algo distinto
        public override string ToString()
        {
            return $" Empleado, Nombre: {Nombre} " + 
                $" Días Vacaciones: {diasVacaciones}";
        }
    }
}