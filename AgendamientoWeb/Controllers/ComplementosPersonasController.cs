using AgendamientoWeb.LogicaDelNegocio.Entidades;
using AgendamientoWeb.LogicaDelNegocio.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendamientoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplementosPersonasController : ControllerBase
    {
        private readonly IComplementosPersonasServicios _complementosPersonasServicios;
        public ComplementosPersonasController(IComplementosPersonasServicios complementosPersonasServicios)
        {

            _complementosPersonasServicios = complementosPersonasServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _complementosPersonasServicios.ConsultarPorId(id));
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ComplementosPersonas obj)
        {

            return Ok(await _complementosPersonasServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] ComplementosPersonas obj)
        {

            return Ok(await _complementosPersonasServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _complementosPersonasServicios.Borrar(id);
            return Ok();
        }

    }
}
