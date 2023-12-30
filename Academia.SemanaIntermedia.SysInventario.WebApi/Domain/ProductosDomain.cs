using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Producto.Dtos;

namespace Academia.SemanaIntermedia.SysInventario.WebApi.Domain
{
    public class ProductosDomain
    {
        public bool InventarioDisponible(List<ProductosLoteDto> productoLoteDto, int cantidadSolicitada)
        {
            int totalProducto = productoLoteDto
                                .Where(dato => dato.InventarioDisponible > 0 && dato.EstaActivo)
                                .Sum(dato => dato.InventarioDisponible);

            return totalProducto >= cantidadSolicitada;
        }

        public bool EsDatoNulo<T>(T datos) => datos == null;

        public bool EsNumerosPositivo(int valor) => valor > 0;
        
    }
}
