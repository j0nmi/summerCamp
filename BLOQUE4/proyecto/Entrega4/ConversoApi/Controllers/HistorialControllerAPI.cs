using Context;
using Entidades.Entities;
using EntidadesDTO.Monedas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using EntidadesDTO.Historial;
using Microsoft.Data.SqlClient;
using System.Data;
using Repositorios;
using Repositorios;

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
            var listaHistorial = _mapper.Map<List<HistorialVerDto>>(await repositorioHistorial.obtenerTodas(usuario));

            return Ok(listaHistorial.ToList()) ;
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
            return Ok(historialUsuario); 
        }
    }
}
