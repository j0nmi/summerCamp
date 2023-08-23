using Context;
using Entidades.Entities;

namespace Repositorios
{
    public class RepositorioPais : IRepositorioPais
    {
        private readonly ContextoConversor _context;

        public RepositorioPais(ContextoConversor context)
        {
            _context = context;
        }
        public Pais alta(Pais? pais)
        {

            Pais existePais = _context.paises.FirstOrDefault(m => m.id == pais.id);

            if (existePais != null)
            {
                existePais.id = pais.id;
                _context.SaveChanges();
            }
            else
            {
                _context.Add(pais);
                _context.SaveChanges();
            }

            return pais;
        }

        public Pais editar(Pais pais)
        {
            Pais existePais = _context.paises.FirstOrDefault(m => m.id == pais.id);

            if (existePais != null)
            {
                existePais.nombre = pais.nombre;
                _context.SaveChanges();
            }
            else
            {
                _context.Add(pais);
                _context.SaveChanges();
            }
            return pais;
        }

        public Pais eliminarPais(Guid id)
        {
            // Seleccionamos Pais a eliminar
            Pais PaisEliminar = _context.paises.FirstOrDefault(m => m.id == id);

            // Si existe
            if (PaisEliminar != null)
            {
                _context.paises.Remove(PaisEliminar);
                _context.SaveChanges();
            }

            return PaisEliminar;
        }

        public Pais obtenerPais(Guid id)
        {

            return _context.paises.FirstOrDefault(m => m.id == id);
        }

        public List<Pais> obtenerTodas()
        {
            return _context.paises.ToList();

        }
    }
}
