using Context;
using Entidades.Entities;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using EntidadesDTO.Usuarios;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Repositorios;

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
            var usuario = await repositorioUsuarios.obtenerUsuario(usuarioCodigo);

            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<UsuarioVerDto>(usuario));
        }
        //actualizar usuarios

        [HttpPatch("{usuarioCodigo}")]
        public async Task<ActionResult> PatchUsuario([FromRoute] Guid usuarioCodigo, [FromBody] JsonPatchDocument<UsuarioActualizarDto> valor)
        {
            var usuario = await repositorioUsuarios.obtenerUsuario(usuarioCodigo);

            if (usuario == null)
            {
                return NotFound();
            }       

            var usuarioDto = _mapper.Map<UsuarioActualizarDto>(usuario);

            valor.ApplyTo(usuarioDto, ModelState);

            _mapper.Map(usuarioDto, usuario);

            await repositorioUsuarios.guardarCambios();

            return NoContent();
        }
    }
}
