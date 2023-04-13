using AgendamientoWeb.LogicaDelNegocio.Entidades;
using AgendamientoWeb.LogicaDelNegocio.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendamientoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        private readonly IEmpresasServicios _empresasServicios;
        public EmpresasController(IEmpresasServicios empresasServicios)
        {

            _empresasServicios = empresasServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _empresasServicios.ConsultarPorId(id));
        }

        [HttpGet]
        [Route("consultarporruta/{rutaempresa}")]
        public async Task<IActionResult> ConsultarPorRutaEmpresa(string rutaempresa)
        {

            return Ok(await _empresasServicios.ConsultarPorRutaEmpresa(rutaempresa));
        }

        [HttpGet]
        [Route("{idTipoDocumentoEmpresa}/{documentoEmpresa}")]
        public async Task<IActionResult> ConsultarPorDocumentoEmpresa(int idTipoDocumentoEmpresa, string documentoEmpresa)
        {

            return Ok(await _empresasServicios.ConsultarPorDocumentoEmpresa(idTipoDocumentoEmpresa, documentoEmpresa));
        }


        [HttpGet]
        [Route("listarpersonasporempresa/{idEmpresa}")]
        public async Task<IActionResult> ListarPersonasPorEmpresas(int idEmpresa)
        {

            return Ok(await _empresasServicios.ListarPersonasPorEmpresas(idEmpresa));
        }

        [HttpGet]
        [Route("listarubicacionesporempresa/{idEmpresa}")]
        public async Task<IActionResult> ListarUbicacionesPorEmpresas(int idEmpresa)
        {

            return Ok(await _empresasServicios.ListarUbicacionesPorEmpresas(idEmpresa));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Empresas obj)
        {

            return Ok(await _empresasServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] Empresas obj)
        {

            return Ok(await _empresasServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _empresasServicios.Borrar(id);
            return Ok();
        }

    }
}
