using AgendamientoWeb.LogicaDelNegocio.Entidades;
using AgendamientoWeb.LogicaDelNegocio.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendamientoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntegrantesPorCitasController : ControllerBase
    {
        private readonly IIntegrantesPorCitasServicios _integrantesPorCitasServicios;
        public IntegrantesPorCitasController(IIntegrantesPorCitasServicios integrantesPorCitasServicios)
        {

            _integrantesPorCitasServicios = integrantesPorCitasServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _integrantesPorCitasServicios.ConsultarPorId(id));
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] IntegrantesPorCitas obj)
        {

            return Ok(await _integrantesPorCitasServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] IntegrantesPorCitas obj)
        {

            return Ok(await _integrantesPorCitasServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _integrantesPorCitasServicios.Borrar(id);
            return Ok();
        }

    }
}
