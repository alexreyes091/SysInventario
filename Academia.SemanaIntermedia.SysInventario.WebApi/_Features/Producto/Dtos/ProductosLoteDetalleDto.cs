using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Inventario.Entities;
using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Producto.Entities;

namespace Academia.SemanaIntermedia.SysInventario.WebApi._Features.Producto.Dtos
{
    public class ProductosLoteDetalleDto
    {
        public int LoteId { get; set; }

        public ProductoDto Producto { get; set; } = new ProductoDto();

        public int? CantidadIngreso { get; set; }

        public double? CostoUnitario { get; set; }

        public DateTime? FechaVencimiento { get; set; }

        public int? InventarioDisponible { get; set; }

        public bool? EstaActivo { get; set; }

    }
}
