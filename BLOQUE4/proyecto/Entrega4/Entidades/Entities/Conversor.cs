using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades.Entities
{
    public class Conversor
    {
        public string monedaOrigen { get; set; }
        public string monedaDestino { get; set; }
        public float cantidad { get; set; }

    }
}