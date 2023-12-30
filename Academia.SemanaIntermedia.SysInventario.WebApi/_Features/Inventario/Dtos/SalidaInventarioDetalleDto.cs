using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Inventario.Entities;
using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Producto.Entities;

namespace Academia.SemanaIntermedia.SysInventario.WebApi._Features.Inventario.Dtos
{
    public class SalidaInventarioDetalleDto
    {
        public int DetalleId { get; set; }

        public int SalidaInventarioId { get; set; }

        public int LoteId { get; set; } 

        public int CantidadProducto { get; set; }

        public DetalleProductoDto Producto { get; set; } = new DetalleProductoDto();

        public DateTime? FechaCreacion { get; set; } = DateTime.Now;

        public DateTime? FechaModificacion { get; set; }
    }
}
