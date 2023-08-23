using Entidades.Entities;

namespace Repositorios
{
    public interface IRepositorioUsuarios
    {
        List<Usuario> obtenerTodos();
        Usuario obtenerUsuario(Guid id);
        Usuario eliminarUsuario(Guid id);
        Usuario alta(Usuario usuario);
        Usuario editar(Usuario usuario);
    }
}
