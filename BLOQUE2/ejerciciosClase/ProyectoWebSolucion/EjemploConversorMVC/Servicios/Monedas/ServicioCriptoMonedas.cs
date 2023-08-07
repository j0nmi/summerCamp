using EjemploConversorMVC.Models;

namespace EjemploConversorMVC.Servicios.Monedas
{
    public class ServicioCriptoMonedas : IServicioMonedas
    {
        public List<Moneda> Monedas { get; set; }
        public List<Moneda> ObtenerMonedas()
        {
            return Monedas;
        }
    }
}
