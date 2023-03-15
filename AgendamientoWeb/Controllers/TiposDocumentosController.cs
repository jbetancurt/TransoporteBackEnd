using AgendamientoWeb.LogicaDelNegocio.Entidades;
using AgendamientoWeb.LogicaDelNegocio.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendamientoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposDocumentosController : ControllerBase
    {
        private readonly ITiposDocumentosServicios _tiposDocumentosServicios;
        public TiposDocumentosController(ITiposDocumentosServicios tiposDocumentosServicios)
        {

            _tiposDocumentosServicios = tiposDocumentosServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _tiposDocumentosServicios.ConsultarPorId(id));
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Todos()
        {

            return Ok(await _tiposDocumentosServicios.ListarTiposDocumentos());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TiposDocumentos obj)
        {

            return Ok(await _tiposDocumentosServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] TiposDocumentos obj)
        {

            return Ok(await _tiposDocumentosServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _tiposDocumentosServicios.Borrar(id);
            return Ok();
        }
    }
}
