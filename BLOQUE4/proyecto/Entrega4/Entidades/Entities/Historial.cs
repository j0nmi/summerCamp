using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades.Entities
{
    public class Historial
    {
        [Key]
        public Guid id { get; set; }
        
        public Guid idUsuario { get; set; }
        [Required]
        public double cantidad { get; set; }

        [Required]
        public string monedaOrigen { get; set; }

        [Required]
        public string monedaDestino { get; set; }

        public double? resultado { get; set; }

        [Required]
        public DateTime fechaConversion { get; set; }
  
    }
}