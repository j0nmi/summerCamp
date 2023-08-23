using Entidades.Entities;

namespace Repositorios
{
    public interface IRepositorioUsuarios
    {
        Usuario obtenerUsuario(Guid id);
        int guardarCambios();
    }
}
