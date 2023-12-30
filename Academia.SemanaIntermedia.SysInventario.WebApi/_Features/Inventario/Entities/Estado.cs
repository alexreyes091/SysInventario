using System;
using System.Collections.Generic;
using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Inventario.Entities;

namespace Academia.SemanaIntermedia.SysInventario.WebApi;

public partial class Estado
{
    public int EstadoId { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Salidasinventario> Salidasinventarios { get; set; } = new List<Salidasinventario>();
}
