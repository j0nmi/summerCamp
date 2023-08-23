using Entidades.Entities;

namespace Repositorios
{
    public interface IRepositorioPais
    {
        List<Pais> obtenerTodas();
        Pais obtenerPais(Guid id);
        Pais alta(Pais pais);
    }
}
