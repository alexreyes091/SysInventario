using System;
using System.Collections.Generic;
using Academia.SemanaIntermedia.SysInventario.WebApi._Common.Entities;
using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Inventario.Entities;

namespace Academia.SemanaIntermedia.SysInventario.WebApi._Features.Usuario.Entities;

public partial class Usuarios : BaseEntity
{
    public int UsuarioId { get; set; }

    public string Usuario { get; set; } = null!;

    public string Clave { get; set; } = null!;

    public int? EmpleadoId { get; set; }

    public int? PerfilId { get; set; }

    public bool? EstaActivo { get; set; }

    public virtual Empleado? Empleado { get; set; }

    public virtual Perfil? Perfil { get; set; }

    public virtual ICollection<Salidasinventario> Salidasinventarios { get; set; } = new List<Salidasinventario>();
}
