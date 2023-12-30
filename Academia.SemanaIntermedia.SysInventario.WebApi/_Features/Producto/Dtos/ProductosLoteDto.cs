using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Inventario.Entities;

namespace Academia.SemanaIntermedia.SysInventario.WebApi._Features.Producto.Dtos
{
    public class ProductosLoteDto
    {
        public int LoteId { get; set; }

        public int ProductosId { get; set; }

        public int CantidadIngreso { get; set; }

        public double CostoUnitario { get; set; }

        public DateTime? FechaVencimiento { get; set; }

        public int InventarioDisponible { get; set; }

        public bool EstaActivo { get; set; }
    }
}
