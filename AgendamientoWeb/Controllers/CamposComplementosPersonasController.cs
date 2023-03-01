using AgendamientoWeb.LogicaDelNegocio.Entidades;
using AgendamientoWeb.LogicaDelNegocio.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendamientoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CamposComplementosPersonasController : ControllerBase
    {
        private readonly ICamposComplementosPersonasServicios _camposComplementosPersonasServicios;
        public CamposComplementosPersonasController(ICamposComplementosPersonasServicios camposComplementosPersonasServicios)
        {

            _camposComplementosPersonasServicios = camposComplementosPersonasServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _camposComplementosPersonasServicios.ConsultarPorId(id));
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CamposComplementosPersonas obj)
        {

            return Ok(await _camposComplementosPersonasServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] CamposComplementosPersonas obj)
        {

            return Ok(await _camposComplementosPersonasServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _camposComplementosPersonasServicios.Borrar(id);
            return Ok();
        }
    }
}
