using Entidades.Entities;

namespace Repositorios
{
    public interface IRepositorioPais
    {
        Task<IEnumerable<Pais>> obtenerTodas();
        Task<Pais> obtenerPais(Guid id);
        Task<Pais> alta(Pais pais);
    }
}
