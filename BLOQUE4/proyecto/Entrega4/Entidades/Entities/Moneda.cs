using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades.Entities
{
    public class Moneda
    {
        [Key]
        public Guid id { get; set; }
        public string? nombre { get; set; }
        public string? codigo { get; set; }
        public float factor { get; set; }
    }
}