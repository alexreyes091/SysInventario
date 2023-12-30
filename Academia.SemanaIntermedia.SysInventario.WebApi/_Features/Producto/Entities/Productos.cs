using Academia.SemanaIntermedia.SysInventario.WebApi._Common.Entities;
using System;
using System.Collections.Generic;

namespace Academia.SemanaIntermedia.SysInventario.WebApi._Features.Producto.Entities;

public partial class Productos : BaseEntity
{
    public int ProductosId { get; set; }

    public string Nombre { get; set; } = null!;

    public bool EstaActivo { get; set; }

    public virtual ICollection<ProductosLote> ProductosLotes { get; set; } = new List<ProductosLote>();
}
