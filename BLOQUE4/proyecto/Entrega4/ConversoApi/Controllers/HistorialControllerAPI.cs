using Context;
using Entidades.Entities;
using EntidadesDTO.Monedas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var listaHistorial = _mapper.Map<List<HistorialVerDto>>(repositorioHistorial.obtenerTodas(usuario));

            return Ok(listaHistorial);
        }

        //Borrar si el usuario lo requiere
        [HttpDelete("{usuario}")]
        public async Task<ActionResult<HistorialActualizarDto>> BorrarHistorial(Guid usuario)
        {
            var historialUsuario = _mapper.Map<List<Historial>>(repositorioHistorial.obtenerTodas(usuario));
            if (historialUsuario == null)
            {
                return NotFound();
            }

            repositorioHistorial.VaciarHistorial(usuario);
            return Ok(historialUsuario); 
        }

        //crear historial
        [HttpPost]
        public async Task<ActionResult<HistorialVerDto>> CreateHistorial([FromBody] HistorialVerDto historial, Guid usuario)
        {
            var listahistorial = _mapper.Map<Historial>(historial);

            repositorioHistorial.crearRegistroHistorial(listahistorial, usuario);

            var historialToReturn = _mapper.Map<HistorialVerDto>(listahistorial);

            return CreatedAtRoute("GetHistorial",
                new { historialId = historialToReturn.id },
                historialToReturn);
        }


    }
}
