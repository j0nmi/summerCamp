using System.ComponentModel.DataAnnotations;

namespace APIMoneda
{
    public class MonedaJson
    {
        public MonedaJson()
        {

        }
        public MonedaJson(string moneda, float valor)
        {
            codigo = moneda;
            factor = valor;
        }

        public string? nombre { get; set; }
        public string? codigo { get; set; }
        public float factor { get; set; }
    }
}
