using DTO;
using DTO.Mappers;
using LogicaAplicacion.InterfacesCU;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtletaController : ControllerBase
    {
        public IListadoAtletas CUListadoAtleta { get; set; }

        public AtletaController(IListadoAtletas cUListadoAtleta)
        {
            CUListadoAtleta = cUListadoAtleta;
        }

        // GET: api/atleta/disciplina/5
        [HttpGet("disciplina/{IdDisciplinas}", Name = "FindById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAtletasPorDisciplina(int IdDisciplinas)
        {
            if (IdDisciplinas <= 0)
            {
                return BadRequest("El ID de la disciplina debe ser un número mayor a 0.");
            }
            if (IdDisciplinas == null)
            {
                return BadRequest("El ID de la disciplina no debe ser vacío.");
            }

            try
            {
                IEnumerable<ListadoAtletasDTO> atletas = CUListadoAtleta.GetAtletasPorDisciplina(IdDisciplinas);

                if (atletas == null)
                {
                    return NotFound("La disciplina con id " + IdDisciplinas + " no existe");
                }

                return Ok(atletas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error inesperado!");
            }
        }

        //// GET: api/atleta
        //[HttpGet]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public IActionResult Get()
        //{
        //    IEnumerable<ListadoAtletasDTO> dto = CUListadoAtleta.GetAtletas();
        //    return Ok(dto);
        //}

        //// POST api/<AtletaController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<AtletaController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<AtletaController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
