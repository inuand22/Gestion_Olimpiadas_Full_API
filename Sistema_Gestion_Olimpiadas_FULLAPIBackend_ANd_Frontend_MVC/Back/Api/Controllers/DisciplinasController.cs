using DTO;
using ExcepcionesPropias;
using LogicaAplicacion.InterfacesCU;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinasController : ControllerBase
    {
        public IListadoDisciplina CUListadoDisciplinas { get; set; }
        public IAltaDisciplina CUAltaDisciplina { get; set; }
        public IUpdateDisciplina CUUpdateDisciplina { get; set; }
        public IRemoveDisciplina CURemoveDisciplina { get; set; }
        public DisciplinasController(IListadoDisciplina cUListadoDisciplinas, IAltaDisciplina cualtaDisciplina,
            IUpdateDisciplina cuUpdateDisciplina, IRemoveDisciplina cURemoveDisciplina)
        {
            CUListadoDisciplinas = cUListadoDisciplinas;
            CUAltaDisciplina = cualtaDisciplina;
            CUUpdateDisciplina = cuUpdateDisciplina;
            CURemoveDisciplina = cURemoveDisciplina;
        }

        // GET: api/<DisciplinasController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            IEnumerable<ListadoDisciplinaDTO> dtoDisciplina = CUListadoDisciplinas.GetDisciplinas();
            return Ok(dtoDisciplina);
        }

        // GET api/<DisciplinasController>/5
        [HttpGet("{id}", Name = "FindXId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("El id debe ser positivo y mayor a cero.");
                }
                if (id == null)
                {
                    return BadRequest("El id no debe ser vacío.");
                }
                ListadoDisciplinaDTO dto = CUListadoDisciplinas.GetDisciplinaXId(id);
                return Ok(dto);
            }
            catch (ExcepcionesDisciplina ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<DisciplinasController>/nombre/{nombre}
        [HttpGet("/nombre/{nombre}", Name = "FindXName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get(string nombre)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    return BadRequest("El nombre de la disciplina no puede estar vacío o ser nulo.");
                }

                ListadoDisciplinaDTO disciplinas = CUListadoDisciplinas.GetDisciplinasPorNombre(nombre);


                if (disciplinas == null)
                {
                    return NotFound("No se encontraron disciplinas con el nombre especificado.");
                }

                return Ok(disciplinas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error interno en el servidor.");
            }
        }


        // POST api/<DisciplinasController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody] AltaDisciplinaDTO dto)
        {
            if (dto == null)
            {
                return BadRequest("La disciplina no puede ser vacía.");
            }
            if (dto.IdDisciplina != 0)
            {
                return BadRequest("No se puede brindar un id para el alta.");
            }
            try
            {
                CUAltaDisciplina.AltaDisci(dto);
                return CreatedAtRoute("FindXId", new { id = dto.IdDisciplina }, dto);
            }
            catch (ExcepcionesDisciplina ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<DisciplinasController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Put(int? id, [FromBody] AltaDisciplinaDTO? dto)
        {
            if (dto == null || id == null)
            {
                return BadRequest("No se proporcionó Disciplina y/o Id para la modificación.");
            }
            if (dto.IdDisciplina != id)
            {
                return BadRequest("Los id no pueden ser diferentes.");
            }
            if (dto.IdDisciplina <= 0 || id <= 0)
            {
                return BadRequest("Los id deben ser enteros positivos.");
            }
            try
            {
                CUUpdateDisciplina.UpdateDisciplina(dto);
                return Ok(dto);
            }
            catch (ExcepcionesDisciplina ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<DisciplinasController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest("No se proporcionó Id para la eliminación.");
            }
            if (id <= 0)
            {
                return BadRequest("El id debe ser entero positivo.");
            }
            try
            {
                CURemoveDisciplina.BorrarDisci(id.Value);
                return NoContent();
            }
            catch (ExcepcionesDisciplina ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message + ex.InnerException);
            }
        }
    }
}
