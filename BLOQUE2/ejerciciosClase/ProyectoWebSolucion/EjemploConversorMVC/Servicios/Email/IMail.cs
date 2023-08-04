using EjemploConversorMVC.Models;

namespace EjemploConversorMVC.Servicios
{
    public interface IMail
    {
        Correo EnviarMail(string correoDestino, string asuntoMail, string contenidoMail);
       
    }
}
