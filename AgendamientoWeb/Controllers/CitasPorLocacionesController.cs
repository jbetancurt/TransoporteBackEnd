using AgendamientoWeb.LogicaDelNegocio.Entidades;
using AgendamientoWeb.LogicaDelNegocio.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendamientoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitasPorLocacionesController : ControllerBase
    {
        private readonly ICitasPorLocacionesServicios _citasPorLocacionesServicios;
        public CitasPorLocacionesController(ICitasPorLocacionesServicios citasPorLocacionesServicios)
        {

            _citasPorLocacionesServicios = citasPorLocacionesServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _citasPorLocacionesServicios.ConsultarPorId(id));
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CitasPorLocaciones obj)
        {

            return Ok(await _citasPorLocacionesServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] CitasPorLocaciones obj)
        {

            return Ok(await _citasPorLocacionesServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _citasPorLocacionesServicios.Borrar(id);
            return Ok();
        }
    }
}
