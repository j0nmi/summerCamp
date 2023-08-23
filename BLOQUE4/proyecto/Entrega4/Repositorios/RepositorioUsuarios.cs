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
        public Usuario alta(Usuario? usuario)
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

        public Usuario editar(Usuario usuario)
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

        public Usuario eliminarUsuario(Guid id)
        {
            // Seleccionamos Usuario a eliminar
            Usuario UsuarioEliminar = _context.usuarios.FirstOrDefault(m => m.id == id);

            // Si existe
            if (UsuarioEliminar != null)
            {
                _context.usuarios.Remove(UsuarioEliminar);
                _context.SaveChanges();
            }

            return UsuarioEliminar;
        }

        public Usuario obtenerUsuario(Guid id)
        {

            return _context.usuarios.FirstOrDefault(m => m.id == id);
        }

        public List<Usuario> obtenerTodos()
        {
            return _context.usuarios.ToList();

        }
    }
}
