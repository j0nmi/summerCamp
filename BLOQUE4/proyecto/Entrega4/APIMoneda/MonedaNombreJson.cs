using System.ComponentModel.DataAnnotations;

namespace APIMoneda
{
    public class MonedaNombreJson
    {
        public MonedaNombreJson()
        {

        }
        public MonedaNombreJson(string codigo, string nombre)
        {
            this.codigo = codigo;
            this.nombre = nombre;
        }

        public string? nombre { get; set; }
        public string? codigo { get; set; }
    }
}
