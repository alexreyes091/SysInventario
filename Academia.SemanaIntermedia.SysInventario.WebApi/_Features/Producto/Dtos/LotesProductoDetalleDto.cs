namespace Academia.SemanaIntermedia.SysInventario.WebApi._Features.Producto.Dtos
{
    public class LotesProductoDetalleDto
    {
        public int ProductosId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public List<ProductosLoteDto> lotes { get; set; }  = new List<ProductosLoteDto>();
    }
}
