using EjemploConversorMVC.Models;

namespace EjemploConversorMVC.Servicios
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
