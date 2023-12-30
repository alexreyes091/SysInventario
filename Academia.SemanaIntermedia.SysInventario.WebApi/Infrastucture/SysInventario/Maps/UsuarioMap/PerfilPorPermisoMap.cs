using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Usuario.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Academia.SemanaIntermedia.SysInventario.WebApi.Infrastucture.SysInventario.Maps.UsuarioMap
{
    public class PerfilPorPermisoMap : IEntityTypeConfiguration<PerfilPorPermiso>
    {
        public void Configure(EntityTypeBuilder<PerfilPorPermiso> builder)
        {
            builder.HasKey(e => new { e.PerfilId, e.PermisoId }).HasName("PK__PerfilPo__256E57743F9E817B");
            builder.Property(e => e.FechaCreacion).HasDefaultValueSql("(getdate())").HasColumnType("datetime");
            builder.Property(e => e.FechaModificacion).HasColumnType("datetime");
        }
    }
}
