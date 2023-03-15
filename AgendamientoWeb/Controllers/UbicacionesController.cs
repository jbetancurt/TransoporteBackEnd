using AgendamientoWeb.LogicaDelNegocio.Entidades;
using AgendamientoWeb.LogicaDelNegocio.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendamientoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UbicacionesController : ControllerBase
    {
        private readonly IUbicacionesServicios _ubicacionesServicios;
        public UbicacionesController(IUbicacionesServicios ubicacionesServicios)
        {

            _ubicacionesServicios = ubicacionesServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _ubicacionesServicios.ConsultarPorId(id));
        }

        [HttpGet]
        [Route("idEmpresa")]
        public async Task<IActionResult> ListarUbicaciones(int idEmpresa)
        {

            return Ok(await _ubicacionesServicios.ListarUbicaciones(idEmpresa));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Ubicaciones obj)
        {

            return Ok(await _ubicacionesServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] Ubicaciones obj)
        {

            return Ok(await _ubicacionesServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _ubicacionesServicios.Borrar(id);
            return Ok();
        }
    }
}
