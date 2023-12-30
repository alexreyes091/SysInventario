using System;
using System.Collections.Generic;
using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Inventario.Entities;

namespace Academia.SemanaIntermedia.SysInventario.WebApi._Features.Sucursal.Entities;

public partial class Sucursale
{
    public int SucursalId { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Salidasinventario> Salidasinventarios { get; set; } = new List<Salidasinventario>();
}
