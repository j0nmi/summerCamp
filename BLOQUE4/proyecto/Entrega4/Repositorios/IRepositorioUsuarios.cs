using Entidades.Entities;

namespace Repositorios
{
    public interface IRepositorioUsuarios
    {
        Task<Usuario> obtenerUsuario(Guid id);
        Task<int> guardarCambios();
        Task<Usuario> alta(Usuario? usuario);
    }
}
