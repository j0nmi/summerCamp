using Context;
using Entidades.Entities;
using EntidadesDTO.Conversor;

namespace Repositorios
{
    public class RepositorioHistorial : IRepositorioHistorial
    {
        private readonly ContextoConversor _context;
        private readonly IRepositorioMonedas repositorioMonedas;

        public RepositorioHistorial(ContextoConversor context, IRepositorioMonedas repositorioMonedas)
        {
            _context = context;
            this.repositorioMonedas = repositorioMonedas;
        }

        public async Task<IEnumerable<Historial>> obtenerTodas(Guid usuario)
        {
            var resultad = _context.historial.Where(m => m.idUsuario == usuario);
            return resultad;
        }

        public async Task<Historial> crearRegistroHistorial(Conversor conversion, Guid usuario)
        {

            Moneda monedaOrigen = await repositorioMonedas.obtenerMoneda(conversion.monedaOrigen);
            Moneda monedaDestino = await repositorioMonedas.obtenerMoneda(conversion.monedaDestino);

            Historial listaHistorial = new Historial();

            listaHistorial.idUsuario = usuario;
            listaHistorial.monedaOrigen = monedaOrigen;
            listaHistorial.monedaDestino = monedaDestino;
            listaHistorial.cantidad = conversion.cantidad;
            listaHistorial.fechaConversion = DateTime.Now;

            // CALCULO

            //Moneda monedaOrigen = await repositorioMonedas.obtenerMoneda(conversion.monedaOrigen);
            //Moneda monedaDestino = await repositorioMonedas.obtenerMoneda(conversion.monedaDestino);

            var resultado = 1 / monedaOrigen.factor * monedaDestino.factor * conversion.cantidad;

            if (resultado != null) listaHistorial.resultadoConversion = resultado;
            else listaHistorial.resultadoConversion = 0;

            _context.Add(listaHistorial);
            _context.SaveChanges();
            return listaHistorial;
        }
        public async Task<string> VaciarHistorial(Guid usuario)
        {
            var historialesUsuario = _context.historial.Where(h => h.idUsuario == usuario).ToList();

            _context.historial.RemoveRange(historialesUsuario);
            _context.SaveChanges();

            return "Borrado";
        }
    }
}
