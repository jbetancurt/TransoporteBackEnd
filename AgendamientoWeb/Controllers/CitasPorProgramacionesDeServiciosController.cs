using AgendamientoWeb.LogicaDelNegocio.Entidades;
using AgendamientoWeb.LogicaDelNegocio.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendamientoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitasPorProgramacionesDeServiciosController : ControllerBase
    {
        private readonly ICitasPorProgramacionesDeServiciosServicios _citasPorProgramacionesDeServiciosServicios;
        public CitasPorProgramacionesDeServiciosController(ICitasPorProgramacionesDeServiciosServicios citasPorProgramacionesDeServiciosServicios)
        {

            _citasPorProgramacionesDeServiciosServicios = citasPorProgramacionesDeServiciosServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _citasPorProgramacionesDeServiciosServicios.ConsultarPorId(id));
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CitasPorProgramacionesDeServicios obj)
        {

            return Ok(await _citasPorProgramacionesDeServiciosServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] CitasPorProgramacionesDeServicios obj)
        {

            return Ok(await _citasPorProgramacionesDeServiciosServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _citasPorProgramacionesDeServiciosServicios.Borrar(id);
            return Ok();
        }

    }
}
