using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Producto.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Academia.SemanaIntermedia.SysInventario.WebApi.Infrastucture.SysInventario.Maps.ProductoMap
{
    public class ProductoMap : IEntityTypeConfiguration<Productos>
    {
        public void Configure(EntityTypeBuilder<Productos> builder)
        {
            builder.ToTable("Productos");
            builder.HasKey(e => e.ProductosId).HasName("PK__Producto__FB3F3BCC87FF1A5C");
            builder.Property(e => e.Nombre).HasMaxLength(50).IsUnicode(false);
            builder.Property(e => e.EstaActivo);
            builder.Property(e => e.FechaCreacion).HasDefaultValueSql("(getdate())").HasColumnType("datetime");
            builder.Property(e => e.FechaModificacion).HasColumnType("datetime");
        }
    }
}
