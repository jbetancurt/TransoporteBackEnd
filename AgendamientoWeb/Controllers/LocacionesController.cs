using AgendamientoWeb.LogicaDelNegocio.Entidades;
using AgendamientoWeb.LogicaDelNegocio.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendamientoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocacionesController : ControllerBase
    {
        private readonly ILocacionesServicios _locacionesServicios;
        public LocacionesController(ILocacionesServicios locacionesServicios)
        {

            _locacionesServicios = locacionesServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _locacionesServicios.ConsultarPorId(id));
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Locaciones obj)
        {

            return Ok(await _locacionesServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] Locaciones obj)
        {

            return Ok(await _locacionesServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _locacionesServicios.Borrar(id);
            return Ok();
        }

    }
}
