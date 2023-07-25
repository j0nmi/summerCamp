using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace explicacionHerencia
{
    public class Administrador : Empleado
    {

        public Administrador(string nombre, bool tienePlazaParking) : base(nombre)
        {
            TienePlazaParking = tienePlazaParking;
        }

        // protected double diasVacaciones;

        public bool TienePlazaParking { get; set; }

        public string PlazaParking()
        {
            throw new ErrorBaseDatosExcepcion(" ERROR al conectar a la BBDD!", DateTime.Now);
            // Condición ? valor_si_verdadero : valor_si_falso;
            return TienePlazaParking ? "Plaza 21" : "No tiene plaza";
        }

        public override void CalculoVacaciones()
        {
            diasVacaciones += 9;
        }
        public override string ToString()
        {
            return $" Administrador, Nombre: {Nombre} |" +
                $" Dias vacaciones: {diasVacaciones} |" +
                $" Plaza Parking: {TienePlazaParking}";
        }
    }
}