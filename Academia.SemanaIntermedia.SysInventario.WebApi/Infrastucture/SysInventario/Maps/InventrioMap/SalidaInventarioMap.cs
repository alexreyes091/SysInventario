using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Inventario.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json.Bson;
using System.Reflection.Emit;

namespace Academia.SemanaIntermedia.SysInventario.WebApi.Infrastucture.SysInventario.Maps.InventrioMap
{
    public class SalidaInventarioMap : IEntityTypeConfiguration<Salidasinventario>
    {
        public void Configure(EntityTypeBuilder<Salidasinventario> builder)
        {
           builder.ToTable("Salidasinventario");
           builder.HasKey(e => e.SalidaInventarioId).HasName("PK__Salidasi__6F7AE0D9824A03E9");
            builder.Property(e => e.FechaCreacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
            builder.Property(e => e.FechaModificacion).HasColumnType("datetime");
            builder.Property(e => e.FechaRecibido).HasColumnType("datetime");
            builder.Property(e => e.FechaSalida).HasColumnType("datetime");

            builder.HasOne(d => d.Estado).WithMany(p => p.Salidasinventarios)
                    .HasForeignKey(d => d.EstadoId)
                    .HasConstraintName("FK__Salidasin__Estad__251C81ED");

            builder.HasOne(d => d.Sucursal).WithMany(p => p.Salidasinventarios)
                    .HasForeignKey(d => d.SucursalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Salidasin__Sucur__2704CA5F");

            builder.HasOne(d => d.Usuario).WithMany(p => p.Salidasinventarios)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Salidasin__Usuar__2610A626");
        }
    }
}
