using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntidadesDTO.Conversor
{
    public class ConversorDto
    {
        public string monedaOrigen { get; set; }
        public string monedaDestino { get; set; }
        public float cantidad { get; set; }
    }
}