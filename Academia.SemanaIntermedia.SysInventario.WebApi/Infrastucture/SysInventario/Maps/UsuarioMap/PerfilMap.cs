using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Usuario.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Academia.SemanaIntermedia.SysInventario.WebApi.Infrastucture.SysInventario.Maps.UsuarioMap
{
    public class PerfilMap : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> builder)
        {
           builder.ToTable("Perfil");
           builder.HasKey(e => e.PerfilId).HasName("PK__Perfil__0C005B06A6A55BB4");
           builder.Property(e => e.Nombre).HasMaxLength(50).IsUnicode(false);
           builder.Property(e => e.FechaCreacion).HasDefaultValueSql("(getdate())").HasColumnType("datetime");
           builder.Property(e => e.FechaModificacion).HasColumnType("datetime");
        }
    }
}
