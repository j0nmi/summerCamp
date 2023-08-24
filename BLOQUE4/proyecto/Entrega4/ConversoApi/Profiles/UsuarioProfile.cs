using AutoMapper;
using Entidades.Entities;
using EntidadesDTO.Usuarios;

namespace ConversoApi.Profiles;
public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<UsuarioVerDto, Usuario>();

        CreateMap<Usuario, UsuarioActualizarDto>();
        CreateMap<UsuarioActualizarDto, Usuario>();

        CreateMap<Usuario, UsuarioVerDto>().ForMember(dest => dest.nombrePais, opt =>
                opt.MapFrom(src => $"{src.pais!.nombre}"));
    }
}
