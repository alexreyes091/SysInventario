using Academia.SemanaIntermedia.SysInventario.WebApi._Common.Entities;
using System;
using System.Collections.Generic;

namespace Academia.SemanaIntermedia.SysInventario.WebApi._Features.Usuario.Entities;

public partial class Permiso : BaseEntity
{
    public int PermisoId { get; set; }

    public string Permisos { get; set; } = null!;

}
