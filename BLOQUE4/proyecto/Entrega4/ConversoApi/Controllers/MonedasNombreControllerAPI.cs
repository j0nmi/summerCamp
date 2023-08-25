using Context;
using Entidades.Entities;
using EntidadesDTO.Monedas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Repositorios;

namespace ConversoApi.Controllers
{
    [Route("api/monedasNombre")]
    [ApiController]
    public class MonedasNombreControllerAPI : ControllerBase
    {
        private readonly IRepositorioMonedasNombre repositorioMonedasNombre;
        private readonly IMapper _mapper;

        public MonedasNombreControllerAPI(IRepositorioMonedasNombre repositorioMonedasNombre,
        IMapper mapper)
        {
            this.repositorioMonedasNombre = repositorioMonedasNombre;
            _mapper = mapper;
        }

        //Obtener TODAS MONEDAS
        [HttpGet]
        public async Task<ActionResult<List<MonedaNombreVerDto>>> Index()
        {
            var listaMonedas = _mapper.Map<List<MonedaNombreVerDto>>(await repositorioMonedasNombre.obtenerTodas());

            return Ok(listaMonedas.ToList());
        }

        //Obtener UNA MONEDA
        [HttpGet("{monedaCodigo}", Name = "GetMonedaNombre")]
        public async Task<ActionResult<string>> GetMoneda([FromRoute] string monedaCodigo)
        {
            var monedaNombre = await repositorioMonedasNombre.obtenerMoneda(monedaCodigo);

            if (monedaNombre == null)
            {
                return NotFound();
            }

            var monedaNombreDto = new MonedaNombreVerDto
            {
                id = monedaNombre.id,
                descripcion = monedaNombre.descripcion,
            };

            return Ok(monedaNombreDto);
        }





    }
}
