using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Producto.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Academia.SemanaIntermedia.SysInventario.WebApi.Infrastucture.SysInventario.Maps.ProductoMap
{
    public class ProductosLoteMap : IEntityTypeConfiguration<ProductosLote>
    {
        public void Configure(EntityTypeBuilder<ProductosLote> builder)
        {
            builder.HasKey(e => e.LoteId).HasName("PK__Producto__E6EAE698AEAC9945");
            builder.HasOne(d => d.Productos).WithMany(p => p.ProductosLotes).
                HasForeignKey(d => d.ProductosId).HasConstraintName("FK__Productos__Produ__22401542");
            builder.Property(e => e.CantidadIngreso).IsRequired();
            builder.Property(e => e.CostoUnitario).IsRequired();
            builder.Property(e => e.InventarioDisponible).IsRequired();
            builder.Property(e => e.EstaActivo);
            builder.Property(e => e.FechaVencimiento).HasColumnType("datetime");
            builder.Property(e => e.FechaCreacion).HasDefaultValueSql("(getdate())").HasColumnType("datetime");
            builder.Property(e => e.FechaModificacion).HasColumnType("datetime");
        }
    }
}


