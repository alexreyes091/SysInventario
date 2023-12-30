using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Inventario.Entities;
using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Sucursal.Entities;
using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Usuario.Entities;

namespace Academia.SemanaIntermedia.SysInventario.WebApi._Features.Inventario.Dtos
{
    public class SalidaInventarioDto
    {
        public int SucursalId { get; set; }

        public int UsuarioId { get; set; }

        public List<SalidaInventarioProductoDto> listaProductos { get; set; } = new List<SalidaInventarioProductoDto>();

    }
}
