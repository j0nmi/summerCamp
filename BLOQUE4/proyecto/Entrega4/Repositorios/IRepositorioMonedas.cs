using Entidades.Entities;

namespace Repositorios
{
    public interface IRepositorioMonedas
    {
        Task<IEnumerable<Moneda>> obtenerTodas();
        Task<Moneda> obtenerMoneda(string prefijo);
        Task<Moneda> alta(Moneda moneda);
    }
}
