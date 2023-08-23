using Context;
using Entidades.Entities;

namespace Repositorios
{
    public class RepositorioUsuarios : IRepositorioUsuarios
    {
        private readonly ContextoConversor _context;

        public RepositorioUsuarios(ContextoConversor context)
        {
            _context = context;
        }

        public Usuario obtenerUsuario(Guid id)
        {

            return _context.usuarios.FirstOrDefault(m => m.id == id);
        }

        public int guardarCambios()
        {
            return _context.SaveChanges();
        }
    }
}
