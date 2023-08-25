using Entidades.Entities;

namespace Repositorios
{
    public interface IRepositorioMonedasNombre
    {
        Task<IEnumerable<MonedaNombre>> obtenerTodas();
        Task<MonedaNombre> obtenerMoneda(string prefijo);
        Task<MonedaNombre> alta(MonedaNombre moneda);
    }
}
