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
