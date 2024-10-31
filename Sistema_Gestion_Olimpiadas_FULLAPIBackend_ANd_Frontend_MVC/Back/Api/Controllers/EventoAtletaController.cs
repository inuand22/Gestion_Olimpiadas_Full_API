using DTO;
using DTO.Mappers;
using ExcepcionesPropias;
using LogicaAplicacion.CU;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoAtletaController : ControllerBase
    {
        public IListadoEventosAtletas CUListadoEventoAtleta { get; set; }

        public EventoAtletaController(IListadoEventosAtletas cUListadoEventoAtleta)
        {
            CUListadoEventoAtleta = cUListadoEventoAtleta;
        }

        // GET: api/<EventoAtletaController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            IEnumerable<ListadoEventoAtletaDTO> dto = CUListadoEventoAtleta.GetAll();
            return Ok(dto);
        }

        // GET api/<EventoAtletaController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest("El id debe ser un número mayor o igual a 1.");
            }

            try
            {
                IEnumerable<ListadoEventoAtletaDTO> eventos = CUListadoEventoAtleta.GetEventosPorAtleta(id);

                if (eventos is not null && eventos.Any())
                {
                    return Ok(eventos);
                }
                else
                {
                    return NotFound("No se encontraron eventos para el atleta especificado.");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrió un error al procesar la solicitud.");
            }
        }

        // GET api/EventoAtleta/rangoPuntaje/10,100
        [HttpGet("rangoPuntaje/{min},{max}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get(decimal min, decimal max)
        {

            if (min < 0 || max < 0)
            {
                return BadRequest("El mínimo y máximo deben ser decimales positivos.");
            }


            if (min > max)
            {
                return BadRequest("El valor mínimo no puede ser mayor al valor máximo.");
            }

            try
            {
                IEnumerable<ListadoEventoAtletaDTO> eventos = CUListadoEventoAtleta.GetAllPorRangoPuntaje(min, max);

                if (eventos is not null && eventos.Any())
                {
                    return Ok(eventos);
                }
                else
                {
                    return NotFound("No se encontraron eventos para el atleta en el rango especificado.");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrió un error al procesar la solicitud.");
            }
        }       
    }
}
