using System.ComponentModel.DataAnnotations;

namespace APIMonedaNombre
{
    public class MonedaJsonN
    {
        public MonedaJsonN()
        {

        }

        public MonedaJsonN(string codigo, string descripcion)
        {
            this.codigo = codigo;
            this.descripcion = descripcion;
        }

        public string? codigo { get; set; }
        public string? descripcion { get; set; }
    }
}
