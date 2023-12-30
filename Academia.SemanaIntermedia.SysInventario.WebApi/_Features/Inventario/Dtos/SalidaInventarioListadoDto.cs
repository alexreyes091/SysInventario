using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Inventario.Entities;
using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Sucursal.Entities;
using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Usuario.Entities;

namespace Academia.SemanaIntermedia.SysInventario.WebApi._Features.Inventario.Dtos
{
    public class SalidaInventarioListadoDto
    {
        public int SalidaInventarioId { get; set; }

        public int SucursalId { get; set; }

        public int UsuarioId { get; set; }

        public List<SalidaInventarioDetalleDto> listadoInventarioDetalle { get; set; } = new List<SalidaInventarioDetalleDto>();

        public DateTime FechaSalida { get; set; } = DateTime.Now;

        public DateTime? FechaRecibido { get; set; } = null;

        public int EstadoId { get; set; }
    }
}
