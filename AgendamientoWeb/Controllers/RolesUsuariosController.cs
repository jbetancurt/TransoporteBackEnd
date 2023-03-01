using AgendamientoWeb.LogicaDelNegocio.Entidades;
using AgendamientoWeb.LogicaDelNegocio.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendamientoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesUsuariosController : ControllerBase
    {
        private readonly IRolesUsuariosServicios _rolesUsuariosServicios;
        public RolesUsuariosController(IRolesUsuariosServicios rolesUsuariosServicios)
        {

            _rolesUsuariosServicios = rolesUsuariosServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _rolesUsuariosServicios.ConsultarPorId(id));
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] RolesUsuarios obj)
        {

            return Ok(await _rolesUsuariosServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] RolesUsuarios obj)
        {

            return Ok(await _rolesUsuariosServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _rolesUsuariosServicios.Borrar(id);
            return Ok();
        }
    }
}
