using AgendamientoWeb.LogicaDelNegocio.Entidades;
using AgendamientoWeb.LogicaDelNegocio.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendamientoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramacionesDeServiciosController : ControllerBase
    {
        private readonly IProgramacionesDeServiciosServicios _programacionesDeServiciosServicios;
        public ProgramacionesDeServiciosController(IProgramacionesDeServiciosServicios programacionesDeServiciosServicios)
        {

            _programacionesDeServiciosServicios = programacionesDeServiciosServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _programacionesDeServiciosServicios.ConsultarPorId(id));
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProgramacionesDeServicios obj)
        {

            return Ok(await _programacionesDeServiciosServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] ProgramacionesDeServicios obj)
        {

            return Ok(await _programacionesDeServiciosServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _programacionesDeServiciosServicios.Borrar(id);
            return Ok();
        }
    }
}
