using Context;
using Entidades.Entities;

namespace Repositorios
{
    public class RepositorioMonedas : IRepositorioMonedas
    {
        private readonly ContextoConversor _context;

        public RepositorioMonedas(ContextoConversor context)
        {
            _context = context;
        }
        public async Task<Moneda> alta(Moneda? moneda)
        {

            Moneda existeMoneda = _context.monedas.FirstOrDefault(m => m.codigo == moneda.codigo);

            if (existeMoneda != null)
            {
                existeMoneda.factor = moneda.factor;
            }
            else
            {
                _context.Add(moneda);
            }
            _context.SaveChanges();
            return moneda;
        }

        public async Task<Moneda> obtenerMoneda(string prefijo)
        {

            return _context.monedas.FirstOrDefault(m => m.codigo == prefijo);
        }

        public async Task<IEnumerable<Moneda>> obtenerTodas()
        {
            return _context.monedas;

        }
    }
}
