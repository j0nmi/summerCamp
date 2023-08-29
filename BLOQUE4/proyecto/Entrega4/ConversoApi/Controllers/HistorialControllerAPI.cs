using Context;
using Entidades.Entities;
using Microsoft.AspNetCore.Mvc;
using Repositorios;
using AutoMapper;
using EntidadesDTO.Historial;

namespace ConversoApi.Controllers
{
    [Route("api/historial")]
    [ApiController]
    public class HistorialControllerAPI : ControllerBase
    {
        private readonly IRepositorioMonedas repositorioMonedas;
        private readonly IRepositorioHistorial repositorioHistorial;
        private readonly IMapper _mapper;

        public HistorialControllerAPI(IRepositorioHistorial repositorioHistorial,
        IMapper mapper)
        {
            this.repositorioHistorial = repositorioHistorial;
            _mapper = mapper;
        }

        //Obtener TODO HISTORIAL
        [HttpGet]
        public async Task<ActionResult<List<HistorialVerDto>>> MostrarHistorial(Guid usuario)
        {
        
            var listaHistorial2 = repositorioHistorial.obtener10Primeras(usuario);

            var listaHistorial = _mapper.Map<List<HistorialVerDto>>(listaHistorial2);

            return Ok(listaHistorial) ;
        }

        //Borrar si el usuario lo requiere
        [HttpDelete("{usuario}")]
        public async Task<ActionResult<HistorialActualizarDto>> BorrarHistorial(Guid usuario)
        {
            var historialUsuario = _mapper.Map<List<Historial>>(await repositorioHistorial.obtenerTodas(usuario));
            if (historialUsuario == null)
            {
                return NotFound();
            }
            await repositorioHistorial.VaciarHistorial(usuario);
            return NoContent(); 
        }
    }
}
