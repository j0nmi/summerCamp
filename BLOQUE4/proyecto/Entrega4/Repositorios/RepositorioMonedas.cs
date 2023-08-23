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
        public Moneda alta(Moneda? moneda)
        {

            Moneda existeMoneda = _context.monedas.FirstOrDefault(m => m.codigo == moneda.codigo);

            if (existeMoneda != null)
            {
                existeMoneda.factor = moneda.factor;
                _context.SaveChanges();
            }
            else
            {
                _context.Add(moneda);
                _context.SaveChanges();
            }

            return moneda;
        }

        public Moneda obtenerMoneda(string prefijo)
        {

            return _context.monedas.FirstOrDefault(m => m.codigo == prefijo);
        }

        public List<Moneda> obtenerTodas()
        {
            return _context.monedas.ToList();

        }
    }
}
