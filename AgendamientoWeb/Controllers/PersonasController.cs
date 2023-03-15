using AgendamientoWeb.LogicaDelNegocio.Entidades;
using AgendamientoWeb.LogicaDelNegocio.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendamientoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly IPersonasServicios _personasServicios;
        public PersonasController(IPersonasServicios personasServicios)
        {

            _personasServicios = personasServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _personasServicios.ConsultarPorId(id));
        }

        [HttpGet]
        [Route("{idTipoDocumento}/{documentoPersona}")]
        public async Task<IActionResult> ConsultarPorDocumento(int idTipoDocumento, string documentoPersona)
        {

            return Ok(await _personasServicios.ConsultarPorDocumento(idTipoDocumento, documentoPersona));
        }



        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Personas obj)
        {

            return Ok(await _personasServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] Personas obj)
        {

            return Ok(await _personasServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _personasServicios.Borrar(id);
            return Ok();
        }
    }
}
