using EjemploConversorMVC.Models;

namespace EjemploConversorMVC.Servicios.Monedas
{
    public class ServicioMonedas : IServicioMonedas
    {

        public List<Moneda> Monedas { get; set; }


        public List<Moneda> ObtenerMonedas()
        {
            return Monedas;
        }
    }
}
