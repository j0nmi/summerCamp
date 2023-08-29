using Context;
using Entidades.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositorios
{
    public class RepositorioUsuarios : IRepositorioUsuarios
    {
        private readonly ContextoConversor _context;

        public RepositorioUsuarios(ContextoConversor context)
        {
            _context = context;
        }

        public async Task<Usuario> obtenerUsuario(Guid id)
        {

            return _context.usuarios.Include(p => p.pais).FirstOrDefault(m => m.id == id);
        }

        public async Task<int> guardarCambios()
        {
            return _context.SaveChanges();
        }

        public async Task<Usuario> alta(Usuario? usuario)
        {
            Usuario existeUsuario = _context.usuarios.FirstOrDefault(m => m.id == usuario.id);
            if (existeUsuario != null)
            {
                existeUsuario.id = usuario.id;
                _context.SaveChanges();
            }
            else
            {
                _context.Add(usuario);
                _context.SaveChanges();
            }
            return usuario;
        }
    }
}
