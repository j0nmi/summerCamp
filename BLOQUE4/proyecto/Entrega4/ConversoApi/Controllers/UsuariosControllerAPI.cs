using Context;
using Entidades.Entities;
using Microsoft.AspNetCore.Mvc;
using Repositorios;
using AutoMapper;
using EntidadesDTO.Usuarios;
using Microsoft.AspNetCore.JsonPatch;

namespace ConversoApi.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuariosControllerAPI : ControllerBase
    {
        private readonly IRepositorioUsuarios repositorioUsuarios;
        private readonly IMapper _mapper;

        public UsuariosControllerAPI(IRepositorioUsuarios repositorioUsuarios,
        IMapper mapper)
        {
            this.repositorioUsuarios = repositorioUsuarios;
            _mapper = mapper;
        }

        
        [HttpGet("{usuarioCodigo}", Name = "GetUsuario")]
        public async Task<ActionResult<UsuarioVerDto>> GetUsuario([FromRoute] Guid usuarioCodigo)
        {
            var usuario = repositorioUsuarios.obtenerUsuario(usuarioCodigo);

            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<UsuarioVerDto>(usuario));
        }
        //actualizar usuarios

        [HttpPatch("{usuarioCodigo}")]
        public async Task<ActionResult> PatchUsuario([FromRoute] Guid usuarioCodigo, [FromBody] JsonPatchDocument<UsuarioActualizar> valor)
        {
            var usuario = repositorioUsuarios.obtenerUsuario(usuarioCodigo);

            if (usuario == null)
            {
                return NotFound();
            }       

            var usuarioDto = _mapper.Map<UsuarioActualizar>(usuario);

            valor.ApplyTo(usuarioDto);

            var usuarioEntidad = _mapper.Map<Usuario>(usuarioDto);

            repositorioUsuarios.editar(usuarioEntidad);

            return NoContent();
        }
    }
}
