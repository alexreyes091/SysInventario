using System;
using System.Collections.Generic;
using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Producto.Entities;

namespace Academia.SemanaIntermedia.SysInventario.WebApi._Features.Inventario.Entities;

public partial class SalidasInventarioDetalle
{
    public int DetalleId { get; set; }

    public int SalidaInventarioId { get; set; }

    public int LoteId { get; set; }

    public int CantidadProducto { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual ProductosLote? Lote { get; set; }

    public virtual Salidasinventario? SalidaInventario { get; set; }
}
