using System.ComponentModel.DataAnnotations;

namespace EntidadesDTO.Paises
{
    public class PaisVerDto
    {
        public Guid id { get; set; }

        public string? bandera { get; set; }

        public string nombre { get; set; }
    }
}