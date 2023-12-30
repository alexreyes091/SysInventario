using Academia.SemanaIntermedia.SysInventario.WebApi._Common.Entities;
using System;
using System.Collections.Generic;

namespace Academia.SemanaIntermedia.SysInventario.WebApi._Features.Usuario.Entities;

public partial class PerfilPorPermiso : BaseEntity
{
    public int PerfilId { get; set; }

    public int PermisoId { get; set; }
}
