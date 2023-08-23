using AutoMapper;
using EntidadesDTO.Monedas;
using Entidades.Entities;

namespace ConversoApi.Profiles;
public class MonedaProfile : Profile
{
    public MonedaProfile()
    {
        //CreateMap<Entidades.Entities.Moneda, Entidades.EntitiesDto.MonedaAltaDto>();
       // CreateMap<MonedaAltaDto, Moneda>();

        CreateMap<Moneda, MonedaVerDto>();
        //CreateMap<Entidades.EntitiesDto.MonedaVerDto, Entidades.Entities.Moneda>();

        //CreateMap<Entidades.EntitiesDto.MonedaAltaDto, Entidades.EntitiesDto.MonedaVerDto>();
        //CreateMap<Entidades.EntitiesDto.MonedaVerDto, Entidades.EntitiesDto.MonedaAltaDto>();
    }
}
