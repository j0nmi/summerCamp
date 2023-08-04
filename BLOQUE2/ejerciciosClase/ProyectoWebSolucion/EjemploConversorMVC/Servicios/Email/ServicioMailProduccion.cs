using EjemploConversorMVC.Models;

namespace EjemploConversorMVC.Servicios.Email
{
    public class ServicioMailProduccion : IMail
    {
        public Correo Correo { get; set; }

        public Correo EnviarMail(string correoDestino, string asuntoMail, string contenidoMail)
        {
            return new Correo
            {
                TipoCorreo = "Produccion",
                CorreoDestino = correoDestino,
                AsuntoMail = asuntoMail,
                ContenidoMail = contenidoMail
            };
        }
    }
}
