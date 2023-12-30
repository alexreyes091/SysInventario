using System;
using System.Collections.Generic;
using Academia.SemanaIntermedia.SysInventario.WebApi._Common.Entities;
using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Usuario.Entities;

namespace Academia.SemanaIntermedia.SysInventario.WebApi;

public partial class Empleado : BaseEntity
{
    public int EmpleadoId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string? Direccion { get; set; }

    public int? Edad { get; set; }

  
    public virtual ICollection<Usuarios> Usuarios { get; set; } = new List<Usuarios>();
}
