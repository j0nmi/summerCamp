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
        public Trabajador(string nombre, string turno) : base(nombre)
        {
            Turno = turno;
        }

        protected double diasVacaciones;

        public string Turno { get; set; }

        public override void CalculoVacaciones()
        {
            // Llamamos al padre
            base.CalculoVacaciones();
            diasVacaciones += 15;
        }

        public override string ToString()
        {
            return $" Trabajador, Nombre: {Nombre} |" +
                $" Días Vacaciones: {diasVacaciones} |" +
                $" Turno: {Turno}";
        }

       
    }
}