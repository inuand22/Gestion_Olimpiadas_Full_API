using DTO;
using LogicaAplicacion.InterfacesCU;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        public IListadoEventos CUListadoEventos { get; set; }
        public EventosController(IListadoEventos cuListadoEventos)
        {
            CUListadoEventos = cuListadoEventos;
        }

        // GET api/<EventosController>/nombre/{name}
        [HttpGet("nombre/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("El nombre no puede estar vacío.");
            }

            try
            {
                IEnumerable<ListadoEventosDTO> eventos = CUListadoEventos.GetEventosPorName(name);

                if (eventos is not null && eventos.Any())
                {
                    return Ok(eventos);
                }
                else
                {
                    return NotFound("No se encontraron eventos con el nombre especificado.");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrió un error al procesar la solicitud.");
            }
        }

        // GET api/<EventosController>/rangoFecha/2024-05-05,2025-02-02
        [HttpGet("rangoFecha/{fechaIni},{fechaFin}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get(DateTime fechaIni, DateTime fechaFin)
        {
            if (fechaIni > fechaFin)
            {
                return BadRequest("La fecha inicial no puede ser posterior a la fecha final.");
            }

            try
            {

                IEnumerable<ListadoEventosDTO> eventos = CUListadoEventos.GetEventosPorRangoFechas(fechaIni, fechaFin);

                if (eventos is not null && eventos.Any())
                {
                    return Ok(eventos);
                }
                else
                {
                    return NotFound("No se encontraron eventos en el rango de fechas especificado.");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrió un error al procesar la solicitud.");
            }
        }

        // GET api/<EventosController>/disciplina/{id}
        [HttpGet("disciplina/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest("El ID de la disciplina debe ser un número positivo.");
            }

            try
            {
                IEnumerable<ListadoEventosDTO> eventos = CUListadoEventos.GetEventosPorIdDisci(id);

                if (eventos is not null && eventos.Any())
                {
                    return Ok(eventos);
                }
                else
                {
                    return NotFound("No se encontraron eventos para la disciplina especificada.");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrió un error al procesar la solicitud.");
            }
        }


        //// POST api/<EventosController>
        //[HttpPost]
        //public IActionResult Post([FromBody] string value)
        //{
        //    return Ok();
        //}

        //// PUT api/<EventosController>/5
        //[HttpPut("{id}")]
        //public IActionResult Put(int id, [FromBody] string value)
        //{
        //    return Ok();
        //}

        //// DELETE api/<EventosController>/5
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    return Ok();
        //}
    }
}
