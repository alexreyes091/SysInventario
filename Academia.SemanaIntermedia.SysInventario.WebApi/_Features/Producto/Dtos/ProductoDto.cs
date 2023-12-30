namespace Academia.SemanaIntermedia.SysInventario.WebApi._Features.Producto.Dtos
{
    public class ProductoDto
    {
        public int ProductosId { get; set; }
        public string Nombre { get; set; } = null!;
        public bool EstaActivo { get; set; }
    }
}
