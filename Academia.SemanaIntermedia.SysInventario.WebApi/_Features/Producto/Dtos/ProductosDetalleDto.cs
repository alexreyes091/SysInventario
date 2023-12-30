namespace Academia.SemanaIntermedia.SysInventario.WebApi._Features.Producto.Dtos
{
    public class ProductosDetalleDto
    {
        public int ProductosId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int CantidadSolicitada { get; set; }
        public List<LoteDetalleDto> LotesDetalle { get; set; } = new List<LoteDetalleDto>();
        public double CostoTotal { get; set; }
    }
}
