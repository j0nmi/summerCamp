using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntidadesDTO.Monedas
{
    public class MonedaAltaDto
    {
        public string? nombre{ get; set; }
        public string? codigo { get; set; }
        public float factor { get; set; }
    }
}