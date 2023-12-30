namespace Academia.SemanaIntermedia.SysInventario.WebApi._Features.Producto.Dtos
{
    public class LoteDetalleDto
    {
        public int LoteId { get; set; }
        public double CostoUnitario { get; set; }
        public int CantidadTomada { get; set; }
        public DateTime? FechaVencimiento { get; set; }
    }
}
