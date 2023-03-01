using AgendamientoWeb.LogicaDelNegocio.Entidades;
using AgendamientoWeb.LogicaDelNegocio.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendamientoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactosEmpresasController : ControllerBase
    {
        private readonly IContactosEmpresasServicios _contactosEmpresasServicios;
        public ContactosEmpresasController(IContactosEmpresasServicios contactosEmpresasServicios)
        {

            _contactosEmpresasServicios = contactosEmpresasServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _contactosEmpresasServicios.ConsultarPorId(id));
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ContactosEmpresas obj)
        {

            return Ok(await _contactosEmpresasServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] ContactosEmpresas obj)
        {

            return Ok(await _contactosEmpresasServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _contactosEmpresasServicios.Borrar(id);
            return Ok();
        }

    }
}
