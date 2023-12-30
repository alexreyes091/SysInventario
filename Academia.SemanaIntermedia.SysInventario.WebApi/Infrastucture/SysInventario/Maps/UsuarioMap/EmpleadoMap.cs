using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academia.SemanaIntermedia.SysInventario.WebApi.Infrastucture.SysInventario.Maps.UsuarioMap
{
    public class EmpleadoMap : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder) 
        {
            builder.ToTable(name: "Empleados");
            builder.HasKey(e => e.EmpleadoId).HasName("PK__Empleado__958BE910E80620AE");
            builder.Property(e => e.Apellido).HasMaxLength(50).IsUnicode(false);
            builder.Property(e => e.Direccion).HasMaxLength(100).IsUnicode(false);
            builder.Property(e => e.FechaCreacion).HasDefaultValueSql("(getdate())").HasColumnType("datetime");
            builder.Property(e => e.FechaModificacion).HasColumnType("datetime");
            builder.Property(e => e.Nombre).HasMaxLength(50).IsUnicode(false);
        }
    }
}
