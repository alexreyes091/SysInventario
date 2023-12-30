using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Inventario.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Academia.SemanaIntermedia.SysInventario.WebApi.Infrastucture.SysInventario.Maps.InventrioMap
{
    public class SalidaInventarioDetalleMap : IEntityTypeConfiguration<SalidasInventarioDetalle>
    {
        public void Configure(EntityTypeBuilder<SalidasInventarioDetalle> builder)
        {
            builder.ToTable("SalidasInventarioDetalle");
            builder.HasKey(e => e.DetalleId).HasName("PK__SalidasI__6E19D6DAED138C4A");
            builder.Property(e => e.FechaCreacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
            builder.Property(e => e.FechaModificacion).HasColumnType("datetime");
            builder.HasOne(d => d.Lote).WithMany(p => p.SalidasInventarioDetalles)
                    .HasForeignKey(d => d.LoteId)
                    .HasConstraintName("FK__SalidasIn__LoteI__2334397B");
            builder.HasOne(d => d.SalidaInventario).WithMany(p => p.SalidasInventarioDetalles)
                    .HasForeignKey(d => d.SalidaInventarioId)
                    .HasConstraintName("FK__SalidasIn__Salid__24285DB4");
        }
    }
}
