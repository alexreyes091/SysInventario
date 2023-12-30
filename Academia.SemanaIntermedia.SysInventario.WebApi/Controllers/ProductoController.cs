using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Producto;
using Farsiman.Domain.Core.Standard.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Academia.SemanaIntermedia.SysInventario.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        private readonly ProductoService _service;


        public ProductoController(ProductoService service)
        {
            _service = service;
        }

        [HttpGet("ProductoPorId")]
        public IActionResult ObtenerProductoPorID(int productoId)
        {
            var respuesta = _service.ObtenerProductoPorId(productoId);
            return Ok(respuesta);
        }

        [HttpGet("ProductoPorLote")]
        public IActionResult ObtenerProductoPorLote(int loteId)
        {
            var respuesta = _service.ObtenerProductosPorLote(loteId);
            return Ok(respuesta);
        }

        [HttpGet("LotesPorProducto")]
        public IActionResult ObtenerLotesPorProducto(int productoId)
        {
            var respuesta = _service.ObtenerLotesPorProducto(productoId);
            return Ok(respuesta);
        }

        [HttpPost("ActualizarLotePorProductos")]
        public IActionResult ActualizarLotesPorProducto(int productoId, int cantidadSolicitada)
        {
            var respuesta = _service.ActualizarRegistroLotesPorProducto(productoId, cantidadSolicitada);
            return Ok(respuesta);
        }

    }
}
