using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace explicacionHerencia
{
    public class Externo : Empleado
    {
        private Empresa empresa;

        public Externo(string nombre, Empresa empresa) : base(nombre)
        {
            this.empresa = empresa;
        }

        //public override string ToString()
        //{
        //    return $" Trabajador, Nombre: {Nombre} |" +
        //        $" Días Vacaciones: {diasVacaciones} |" +
        //        $" Turno: {Turno}";
        //}
    }
}