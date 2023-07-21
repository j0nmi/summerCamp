using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace explicacionHerencia
{
    public class Trabajador : Empleado
    {
        // Si no creamos el constructor predeterminado. 
        // Obliga a introducir nombre y se lo pasa al padre
        public Trabajador(string nombre) : base(nombre)
        {
        }

        protected double diasVacaciones;
        public override string ToString()
        {
            return $" Trabajador, Nombre: {Nombre} " +
                $" Días Vacaciones: {diasVacaciones}";
        }
    }
}