using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Inventario;
using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Inventario.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Academia.SemanaIntermedia.SysInventario.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventrioController : ControllerBase
    {
        private readonly InventarioService _service;
        public InventrioController(InventarioService service)
        {
            _service = service;
        }

        [HttpPost("CrearSalidaInventarioPorSucursal")]
        public IActionResult RegistrarSalidaInventario(SalidaInventarioDto solicitudSalida)
        {
            var respuesta = _service.RegistrarSalidaInventario(solicitudSalida);
            return Ok(respuesta);
        }

        [HttpGet("ObtenerDetalleInventarioPorSucursal")]
        public IActionResult ObtenerInventarioPorSucursal(int sucursalId)
        {
            var respuesta = _service.ObtenerListadoInventarioPorSucursal(sucursalId);
            return Ok(respuesta);
        }

        [HttpPut("RecibirInventarioPorSucursal")]
        public IActionResult ActualizarInventarioPorSucursal(int sucursalId, int salidaInventarioId)
        {
            var respuesta = _service.RecibirInventarioPorSucursal(sucursalId, salidaInventarioId);
            return Ok(respuesta);
        }

    }
}
