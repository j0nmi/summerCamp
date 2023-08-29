using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesDTO.Historial
{
    public class HistorialProcedure
    {
        public Guid id {  get; set; }
        public string email {  get; set; }
        public string moneda1 { get; set; }
        public string moneda2 { get; set; }

        public float? resultadoConversion { get; set; }

        public DateTime fechaConversion { get; set; }

        public double cantidad { get; set; }


    }
}
