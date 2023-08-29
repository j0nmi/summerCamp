using Entidades.Entities;
using EntidadesDTO.Historial;

namespace Repositorios
{
    public interface IRepositorioHistorial
    {
        Task<IEnumerable<Historial>> obtenerTodas(Guid usuario);
        IEnumerable<HistorialProcedure> obtener10Primeras(Guid usuario);

        Task<Historial> crearRegistroHistorial(Conversor conversion, Guid usuario);
        Task<string> VaciarHistorial(Guid usuario);
    }
}