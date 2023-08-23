using Context;
using Entidades.Entities;

namespace Repositorios
{
    public class RepositorioHistorial : IRepositorioHistorial
    {
        private readonly ContextoConversor _context;

        public RepositorioHistorial(ContextoConversor context)
        {
            _context = context;
        }

        public List<Historial> obtenerTodas(Guid usuario)
        {
            return _context.historial.Where(m => m.id == usuario).ToList();
        }

        public Historial crearRegistroHistorial(Historial historial, Guid usuario)
        {
            Historial listaHistorial = new Historial();

            listaHistorial.idUsuario = usuario;
            listaHistorial.monedaOrigen = historial.monedaOrigen;
            listaHistorial.monedaDestino = historial.monedaDestino;
            listaHistorial.cantidad = historial.cantidad;
            listaHistorial.fechaConversion = DateTime.Now;
            listaHistorial.resultado = historial.resultado;
            if (historial.resultado != null) listaHistorial.resultado = historial.resultado;
            else listaHistorial.resultado = 0;

            _context.Add(listaHistorial);
            _context.SaveChanges();
            return listaHistorial;
        }
        public List<Historial> VaciarHistorial(Guid usuario)
        {
            var historialesUsuario = _context.historial.Where(h => h.idUsuario == usuario).ToList();

            _context.historial.RemoveRange(historialesUsuario);
            _context.SaveChanges();

            return _context.historial.Where(m => m.id == usuario).ToList();
        }
    }
}
