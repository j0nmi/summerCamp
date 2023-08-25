using Entidades.Entities;
using EntidadesDTO.Conversor;
using EntidadesDTO.Historial;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Repositorios;

namespace ConversoApi.Controllers
{
    [Route("api/conversor")]
    [ApiController]
    public class ConversorControllerAPI : ControllerBase
    {
        private readonly IRepositorioHistorial repositorioHistorial;
        private readonly IMapper _mapper;

        public ConversorControllerAPI(IRepositorioHistorial repositorioHistorial,
        IMapper mapper)
        {
            this.repositorioHistorial = repositorioHistorial;
            _mapper = mapper;
        }

        //CONVERSION Y CREAR HISTORIAL
        [HttpPost]
        public async Task<ActionResult<HistorialVerDto>> ResultadoHistorial([FromBody] ConversorDto conversion, Guid usuario)
        {
            var conversionEntidad = _mapper.Map<Conversor>(conversion);

            Historial historial = await repositorioHistorial.crearRegistroHistorial(conversionEntidad, usuario);

            //var historialToReturn = _mapper.Map<HistorialVerDto>(historial);

            return Ok(historial);
        }




    }
}
