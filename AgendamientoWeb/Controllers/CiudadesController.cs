using AgendamientoWeb.LogicaDelNegocio.Entidades;
using AgendamientoWeb.LogicaDelNegocio.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendamientoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CiudadesController : ControllerBase
    {
        private readonly ICiudadesServicios _ciudadesServicios;
        public CiudadesController(ICiudadesServicios ciudadesServicios)
        {

            _ciudadesServicios = ciudadesServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _ciudadesServicios.ConsultarPorId(id));
        }

        [HttpGet]
        [Route("ListarCiudades/{CodigoDepartamento}")]
       
        public async Task<IActionResult> ListarCiudades(string CodigoDepartamento)
        {

            return Ok(await _ciudadesServicios.ListarCiudadesPorDepartamento(CodigoDepartamento));
        }

        [HttpGet]
        [Route("ListarDepartamentos/{idPais}")]

        public async Task<IActionResult> ListarDepartamentos(int idPais)
        {

            return Ok(await _ciudadesServicios.ListarDepartamentosPorPais(idPais));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Ciudades obj)
        {

            return Ok(await _ciudadesServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] Ciudades obj)
        {

            return Ok(await _ciudadesServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _ciudadesServicios.Borrar(id);
            return Ok();
        }

    }
}
