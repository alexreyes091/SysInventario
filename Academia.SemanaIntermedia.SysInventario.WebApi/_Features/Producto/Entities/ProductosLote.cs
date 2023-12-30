using System;
using System.Collections.Generic;
using Academia.SemanaIntermedia.SysInventario.WebApi._Common.Entities;
using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Inventario.Entities;

namespace Academia.SemanaIntermedia.SysInventario.WebApi._Features.Producto.Entities;

public partial class ProductosLote : BaseEntity
{
    public int LoteId { get; set; }

    public int ProductosId { get; set; }

    public int CantidadIngreso { get; set; }

    public double CostoUnitario { get; set; }

    public DateTime FechaVencimiento { get; set; }

    public int InventarioDisponible { get; set; }

    public bool EstaActivo { get; set; }

    public virtual Productos? Productos { get; set; }

    public virtual ICollection<SalidasInventarioDetalle> SalidasInventarioDetalles { get; set; } = new List<SalidasInventarioDetalle>();
}
