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

        public Moneda editar(Moneda moneda)
        {
            Moneda existeMoneda = _context.monedas.FirstOrDefault(m => m.codigo == moneda.codigo);

            if (existeMoneda != null)
            {
                existeMoneda.nombre = moneda.nombre;
                _context.SaveChanges();
            }
            else
            {
                _context.Add(moneda);
                _context.SaveChanges();
            }
            return moneda;
        }

        public Moneda eliminarMoneda(string prefijo)
        {
            // Seleccionamos moneda a eliminar
            Moneda monedaEliminar = _context.monedas.FirstOrDefault(m => m.codigo == prefijo);

            // Si existe
            if (monedaEliminar != null)
            {
                _context.monedas.Remove(monedaEliminar);
                _context.SaveChanges();
            }

            return monedaEliminar;
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
