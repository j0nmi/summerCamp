﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace explicacionHerencia
{
    public class ErrorBaseDatosExcepcion : Exception
    {
        public string Mensaje { get; set; }
        public DateTime FechaHoraExcepcion { get; set; }
        public ErrorBaseDatosExcepcion(string mensaje, DateTime fechaHoraExcepcion) : base(mensaje)
        {
            Mensaje = mensaje;
            FechaHoraExcepcion = fechaHoraExcepcion;
        }
    }
}
