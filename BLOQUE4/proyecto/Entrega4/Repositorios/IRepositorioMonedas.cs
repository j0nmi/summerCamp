using Entidades.Entities;

namespace Repositorios
{
    public interface IRepositorioMonedas
    {
        List<Moneda> obtenerTodas();
        Moneda obtenerMoneda(string prefijo);
        Moneda eliminarMoneda(string prefijo);
        Moneda alta(Moneda moneda);
        Moneda editar(Moneda moneda);
    }
}
