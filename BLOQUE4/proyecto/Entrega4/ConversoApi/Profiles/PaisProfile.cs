using AutoMapper;
using EntidadesDTO.Paises;
using Entidades.Entities;

namespace ConversoApi.Profiles;
public class PaisProfile : Profile
{
    public PaisProfile()
    {
       // CreateMap<PaisAltaDto, Pais>();

        CreateMap<Pais, PaisVerDto>();
    }
}
