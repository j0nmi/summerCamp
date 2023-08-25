using AutoMapper;
using EntidadesDTO.Monedas;
using Entidades.Entities;

namespace ConversoApi.Profiles;
public class MonedaNombreProfile : Profile
{
    public MonedaNombreProfile()
    {

        CreateMap<MonedaNombre, MonedaNombreVerDto>();
    }
}
