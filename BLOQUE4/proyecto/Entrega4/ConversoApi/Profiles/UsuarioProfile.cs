using AutoMapper;
using Entidades.Entities;
using EntidadesDTO.Usuarios;

namespace ConversoApi.Profiles;
public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<UsuarioVerDto, Usuario>();

        CreateMap<Usuario, UsuarioActualizar>();

        CreateMap<UsuarioActualizar, Usuario>();
    }
}
