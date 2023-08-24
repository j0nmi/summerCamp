using AutoMapper;
using EntidadesDTO.Paises;
using Entidades.Entities;
using EntidadesDTO.Conversor;

namespace ConversoApi.Profiles;
public class ConversorProfile : Profile
{
    public ConversorProfile()
    {
 
        CreateMap<ConversorDto, Conversor>();
    }
}
