using AgendamientoWeb.LogicaDelNegocio.Entidades;
using AgendamientoWeb.LogicaDelNegocio.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendamientoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitasController : ControllerBase
    {
        private readonly ICitasServicios _citasServicios;
        public CitasController(ICitasServicios citasServicios)
        {

            _citasServicios = citasServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _citasServicios.ConsultarPorId(id));
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Citas obj)
        {

            return Ok(await _citasServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] Citas obj)
        {

            return Ok(await _citasServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _citasServicios.Borrar(id);
            return Ok();
        }
    }
}
