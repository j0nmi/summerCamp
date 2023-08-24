using Entidades.Entities;

namespace Repositorios
{
    public interface IRepositorioHistorial
    {
        Task<IEnumerable<Historial>> obtenerTodas(Guid usuario);

        Task<Historial> crearRegistroHistorial(Conversor conversion, Guid usuario);
        Task<string> VaciarHistorial(Guid usuario);
    }
}