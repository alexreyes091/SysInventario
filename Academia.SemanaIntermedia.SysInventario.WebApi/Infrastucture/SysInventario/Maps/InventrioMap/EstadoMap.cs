using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Academia.SemanaIntermedia.SysInventario.WebApi.Infrastucture.SysInventario.Maps.InventrioMap
{
    public class EstadoMap : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder.ToTable(name: "Estado");
            builder.HasKey(e => e.EstadoId).HasName("PK__Estados__FEF86B00D858611F");
            builder.Property(e => e.EstadoId).ValueGeneratedNever();
            builder.Property(e => e.Nombre).HasMaxLength(50).IsUnicode(false);
        }
    }
}
