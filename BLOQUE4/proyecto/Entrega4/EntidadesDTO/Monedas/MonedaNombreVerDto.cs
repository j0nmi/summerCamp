using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntidadesDTO.Monedas
{
    public class MonedaNombreVerDto
    {
        public Guid id { get; set; }
        public string? codigo { get; set; }
        public string? descripcion { get; set; }
    }
}