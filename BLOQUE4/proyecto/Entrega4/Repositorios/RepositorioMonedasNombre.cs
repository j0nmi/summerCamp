using Context;
using Entidades.Entities;

namespace Repositorios
{
    public class RepositorioMonedasNombre : IRepositorioMonedasNombre
    {
        private readonly ContextoConversor _context;

        public RepositorioMonedasNombre(ContextoConversor context)
        {
            _context = context;
        }
        public async Task<MonedaNombre> alta(MonedaNombre? monedaNombre)
        {
            MonedaNombre existeMonedaNombre = _context.monedasNombre.FirstOrDefault(m => m.codigo == monedaNombre.codigo);

            if (existeMonedaNombre != null)
            {
                existeMonedaNombre.descripcion = monedaNombre.descripcion;
            }
            else
            {
                _context.Add(existeMonedaNombre);
            }

            _context.SaveChanges();
            return existeMonedaNombre;
        }

        public async Task<MonedaNombre> obtenerMoneda(string prefijo)
        {

            return _context.monedasNombre.FirstOrDefault(m => m.codigo == prefijo);
        }

        public async Task<IEnumerable<MonedaNombre>> obtenerTodas()
        {
            return _context.monedasNombre;

        }
    }
}
