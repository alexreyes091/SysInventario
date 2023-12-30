using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Usuario.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Academia.SemanaIntermedia.SysInventario.WebApi.Infrastucture.SysInventario.Maps.UsuarioMap
{
    public class PermisoMap : IEntityTypeConfiguration<Permiso>
    {
        public void Configure(EntityTypeBuilder<Permiso> builder)
        {
           builder.HasKey(e => e.PermisoId).HasName("PK__Permisos__96E0C723A564C74C");
           builder.Property(e => e.Permisos).HasMaxLength(255);
           builder.Property(e => e.FechaCreacion).HasDefaultValueSql("(getdate())").HasColumnType("datetime");
           builder.Property(e => e.FechaModificacion).HasColumnType("datetime");
        }
    }
}
