using EjemploConversorMVC.Models;

namespace EjemploConversorMVC.Servicios.Email
{
    public class ServicioMailDesarrollo : IMail
    {
        public Correo Correo { get; set; }
        public Correo EnviarMail(string correoDestino, string asuntoMail, string contenidoMail)
        {
            return new Correo
            {
                TipoCorreo = "Desarrollo",
                CorreoDestino = correoDestino,
                AsuntoMail = asuntoMail,
                ContenidoMail = contenidoMail
            };
        }
    }
}
