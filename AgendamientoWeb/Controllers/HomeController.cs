using AgendamientoWeb.LogicaDelNegocio.Services;
using AgendamientoWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AgendamientoWeb.Controllers
{
    //aca le decimos  la ruta para acceder a esta pagina
	[Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
	{
		
        private readonly IUsuariosServicios _usuariosServicios;
		public HomeController(IUsuariosServicios usuariosServicios)
		{
		
            _usuariosServicios= usuariosServicios;
		}
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            
            return Ok(await _usuariosServicios.ConsultarPorId(id));
        }
 
		
	}
}