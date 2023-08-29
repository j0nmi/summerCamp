using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntidadesDTO.Historial
{
    public class HistorialVerDto
    {
        public Guid id { get; set; }
        public Guid idUsuario { get; set; }
        public double cantidad { get; set; }

        public string moneda1 { get; set; }

        public string moneda2 { get; set; }

        public float? resultadoConversion { get; set; }

        public DateTime fechaConversion { get; set; }
  
    }
}