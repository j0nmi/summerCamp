using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades.Entities
{
    public class MonedaNombre
    {
        [Key]
        public Guid id { get; set; }
        public string? codigo { get; set; }
        public string? descripcion { get; set; }
    }
}