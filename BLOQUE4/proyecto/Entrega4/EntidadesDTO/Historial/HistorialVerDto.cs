using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntidadesDTO.Historial
{
    public class HistorialVerDto
    {
        public Guid id { get; set; }
        public int idUsuario { get; set; }
        public double cantidad { get; set; }

        public string monedaOrigen { get; set; }

        public string monedaDestino { get; set; }

        public double? resultadoConversion { get; set; }

        public DateTime fechaConversion { get; set; }
  
    }
}