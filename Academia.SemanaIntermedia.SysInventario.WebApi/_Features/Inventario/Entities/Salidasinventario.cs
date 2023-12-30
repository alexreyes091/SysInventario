using System;
using System.Collections.Generic;
using Academia.SemanaIntermedia.SysInventario.WebApi._Common.Entities;
using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Sucursal.Entities;
using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Usuario.Entities;

namespace Academia.SemanaIntermedia.SysInventario.WebApi._Features.Inventario.Entities;

public partial class Salidasinventario : BaseEntity
{
    public int SalidaInventarioId { get; set; }

    public int SucursalId { get; set; }

    public int UsuarioId { get; set; }

    public int Total { get; set; }

    public DateTime FechaSalida { get; set; } = DateTime.Now;

    public DateTime? FechaRecibido { get; set; } = null;

    public int EstadoId { get; set; }

    public virtual Estado? Estado { get; set; }

    public virtual ICollection<SalidasInventarioDetalle> SalidasInventarioDetalles { get; set; } = new List<SalidasInventarioDetalle>();

    public virtual Sucursale Sucursal { get; set; } = null!;

    public virtual Usuarios Usuario { get; set; } = null!;
}
