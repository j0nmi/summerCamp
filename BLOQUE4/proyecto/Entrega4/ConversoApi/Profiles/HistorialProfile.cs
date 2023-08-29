using AutoMapper;
using EntidadesDTO.Paises;
using Entidades.Entities;
using EntidadesDTO.Historial;

namespace ConversoApi.Profiles;
public class HistorialProfile : Profile
{
    public HistorialProfile()
    {

        CreateMap<Historial, HistorialVerDto>();
        CreateMap<Historial, HistorialActualizarDto>();

        CreateMap<HistorialProcedure, HistorialVerDto>();
    }
}
