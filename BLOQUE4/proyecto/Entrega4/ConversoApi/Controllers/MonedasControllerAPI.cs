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
    [Route("api/monedas")]
    [ApiController]
    public class MonedasControllerAPI : ControllerBase
    {
        private readonly IRepositorioMonedas repositorioMonedas;
        private readonly IMapper _mapper;

        public MonedasControllerAPI(IRepositorioMonedas repositorioMonedas,
        IMapper mapper)
        {
            this.repositorioMonedas = repositorioMonedas;
            _mapper = mapper;
        }

        //Obtener TODAS MONEDAS
        [HttpGet]
        public async Task<ActionResult<List<MonedaVerDto>>> Index()
        {
            var listaMonedas = _mapper.Map<List<MonedaVerDto>>(await repositorioMonedas.obtenerTodas());

            return Ok(listaMonedas.ToList());
        }

        //Obtener UNA MONEDA
        [HttpGet("{monedaCodigo}", Name = "GetMoneda")]
        public async Task<ActionResult<string>> GetMoneda([FromRoute] string monedaCodigo)
        {
            var moneda = await repositorioMonedas.obtenerMoneda(monedaCodigo);

            if (moneda == null)
            {
                return NotFound();
            }

            var monedaDto = new MonedaVerDto
            {
                id = moneda.id,
                nombre = moneda.nombre,
                codigo = moneda.codigo,
                factor = moneda.factor
            };

            return Ok(monedaDto.resumenMoneda);
        }





    }
}
