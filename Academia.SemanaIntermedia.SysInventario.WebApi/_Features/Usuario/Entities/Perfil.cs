using Academia.SemanaIntermedia.SysInventario.WebApi._Common.Entities;
using System;
using System.Collections.Generic;

namespace Academia.SemanaIntermedia.SysInventario.WebApi._Features.Usuario.Entities;

public partial class Perfil : BaseEntity
{
    public int PerfilId { get; set; }

    public string Nombre { get; set; } = null!;

    public bool? EstaActivo { get; set; }

    public virtual ICollection<Usuarios> Usuarios { get; set; } = new List<Usuarios>();
}
