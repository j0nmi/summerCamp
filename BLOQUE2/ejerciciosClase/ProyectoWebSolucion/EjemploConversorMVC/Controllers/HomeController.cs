using EjemploConversorMVC.Models;
using EjemploConversorMVC.Servicios;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EjemploConversorMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServicioMonedas servicioMonedas;
        private readonly IMail servicioMail;

        public HomeController(ILogger<HomeController> logger, IServicioMonedas servicioMonedas, IMail servicioMail)
        {
            _logger = logger;
            this.servicioMonedas = servicioMonedas;
            this.servicioMail = servicioMail;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("\n Estoy en el index");
            var lista = this.servicioMonedas.ObtenerMonedas();

            return View();
        }

        public IActionResult Privacy()
        {
            var correo = servicioMail.EnviarMail("pepe@tracasa.es", "CORREO IMPORTANTE", "Hola Pepe, esto es importante.");
            ViewBag.Correo = "De: " + correo.TipoCorreo + " | Para: " + correo.CorreoDestino + " | Asunto: " + correo.AsuntoMail + " | Mensaje: " + correo.ContenidoMail;
            

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}