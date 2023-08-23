using Entidades.Entities;

namespace Repositorios
{
    public interface IRepositorioHistorial
    {
        List<Historial> obtenerTodas(Guid usuario);

        Historial crearRegistroHistorial(Historial historial, Guid usuario);
        List<Historial> VaciarHistorial(Guid usuario);
    }
}