using Entidades.Entities;

namespace Repositorios
{
    public interface IRepositorioPais
    {
        List<Pais> obtenerTodas();
        Pais obtenerPais(Guid id);
        Pais eliminarPais(Guid id);
        Pais alta(Pais pais);
        Pais editar(Pais pais);
    }
}
