using AgendamientoWeb.LogicaDelNegocio.Entidades;
using AgendamientoWeb.LogicaDelNegocio.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendamientoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasPorEmpresasController : ControllerBase
    {
        private readonly IPersonasPorEmpresasServicios _personasPorEmpresasServicios;
        public PersonasPorEmpresasController(IPersonasPorEmpresasServicios personasPorEmpresasServicios)
        {

            _personasPorEmpresasServicios = personasPorEmpresasServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _personasPorEmpresasServicios.ConsultarPorId(id));
        }

        [HttpGet]
        [Route("{idEmpresa}/{idPersona}")]
        public async Task<IActionResult> ConsultarPorIdPersonayIdEmpresa(int idEmpresa, int idPersona)
        {
            return Ok(await _personasPorEmpresasServicios.ConsultarPorIdPersonayIdEmpresa(idEmpresa, idPersona));
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PersonasPorEmpresas obj)
        {

            return Ok(await _personasPorEmpresasServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] PersonasPorEmpresas obj)
        {

            return Ok(await _personasPorEmpresasServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _personasPorEmpresasServicios.Borrar(id);
            return Ok();
        }
    }
}
