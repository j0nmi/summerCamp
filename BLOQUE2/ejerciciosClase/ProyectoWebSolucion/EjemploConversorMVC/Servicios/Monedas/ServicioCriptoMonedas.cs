using EjemploConversorMVC.Models;
using EjemploConversorMVC.Servicios;

namespace EjemploConversorMVC.Servicios
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
