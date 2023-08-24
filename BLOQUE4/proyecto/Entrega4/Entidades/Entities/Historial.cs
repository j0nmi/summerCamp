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
        [ForeignKey("moneda1")]
        [Required]
        public Moneda monedaOrigen { get; set; }
        [ForeignKey("moneda2")]
        [Required]
        public Moneda monedaDestino { get; set; }

        public float? resultadoConversion { get; set; }

        [Required]
        public DateTime fechaConversion { get; set; }


        [ForeignKey("idUsuario")]
        public Usuario usuario { get; set; }
        
        public Guid moneda1 { get; set; }
        
        public Guid moneda2 { get; set; }
    }
}