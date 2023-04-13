using AgendamientoWeb.LogicaDelNegocio.Entidades;
using AgendamientoWeb.LogicaDelNegocio.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendamientoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrosDeCambiosController : ControllerBase
    {
        private readonly IRegistrosDeCambiosServicios _registrosDeCambiosServicios;
        public RegistrosDeCambiosController(IRegistrosDeCambiosServicios registrosDeCambiosServicios)
        {

            _registrosDeCambiosServicios = registrosDeCambiosServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _registrosDeCambiosServicios.ConsultarPorId(id));
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] RegistrosDeCambios obj)
        {

            return Ok(await _registrosDeCambiosServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] RegistrosDeCambios obj)
        {

            return Ok(await _registrosDeCambiosServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _registrosDeCambiosServicios.Borrar(id);
            return Ok();
        }
    }
}



