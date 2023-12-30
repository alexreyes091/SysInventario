using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Usuario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Academia.SemanaIntermedia.SysInventario.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _service;

        public UsuarioController(UsuarioService service)
        {
            _service = service;
        }

        [HttpGet("ListaUsuarios")]
        public IActionResult ObtenerListaUsuarios()
        {
            var repsuesta = _service.ObtenerListaUsuarios();
            return Ok(repsuesta);
        }
    }
}
