using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntidadesDTO.Historial
{
    public class HistorialActualizarDto
    {
        public Guid id { get; set; }
        public Guid idUsuario { get; set; }
        public double cantidad { get; set; }

        public string monedaOrigen { get; set; }

        public string monedaDestino { get; set; }

        public float? resultadoConversion { get; set; }

        public DateTime fechaConversion { get; set; }
  
    }
}