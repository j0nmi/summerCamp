using System.ComponentModel.DataAnnotations;

namespace APIPaises
{
    public class PaisJson
    {
        public PaisJson()
        {

        }
        public PaisJson(string prefijo, string nombre)
        {
            this.prefijo = prefijo;
            this.nombre = nombre;
        }

        public string? prefijo { get; set; }
        public string? nombre { get; set; }
    }
}
