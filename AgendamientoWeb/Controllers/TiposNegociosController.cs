using AgendamientoWeb.LogicaDelNegocio.Entidades;
using AgendamientoWeb.LogicaDelNegocio.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendamientoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposNegociosController : ControllerBase
    {
        private readonly ITiposNegociosServicios _tiposNegociosServicios;
        public TiposNegociosController(ITiposNegociosServicios tiposNegociosServicios)
        {

            _tiposNegociosServicios = tiposNegociosServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _tiposNegociosServicios.ConsultarPorId(id));
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TiposNegocios obj)
        {

            return Ok(await _tiposNegociosServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] TiposNegocios obj)
        {

            return Ok(await _tiposNegociosServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _tiposNegociosServicios.Borrar(id);
            return Ok();
        }
    }
}
