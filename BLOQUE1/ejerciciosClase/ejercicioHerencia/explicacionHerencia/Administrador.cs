using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace explicacionHerencia
{
    public class Administrador : Empleado
    {
        public Administrador(string nombre) : base(nombre)
        {
        }

        protected double diasVacaciones;
        public override string ToString()
        {
            return $" Administrador, Nombre: {Nombre} " +
                $" Días Vacaciones: {diasVacaciones}";
        }
    }
}