using System;
using System.Collections.Generic;
using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Inventario.Entities;
using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Producto.Entities;
using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Sucursal.Entities;
using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Usuario.Entities;
using Academia.SemanaIntermedia.SysInventario.WebApi.Infrastucture.SysInventario.Maps.InventrioMap;
using Academia.SemanaIntermedia.SysInventario.WebApi.Infrastucture.SysInventario.Maps.ProductoMap;
using Academia.SemanaIntermedia.SysInventario.WebApi.Infrastucture.SysInventario.Maps.UsuarioMap;
using Microsoft.EntityFrameworkCore;

namespace Academia.SemanaIntermedia.SysInventario.WebApi.Infrastucture.SysInventario;

public partial class SysInventarioDbContext : DbContext
{
    public SysInventarioDbContext()
    {
    }

    public SysInventarioDbContext(DbContextOptions<SysInventarioDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Perfil> Perfils { get; set; }

    public virtual DbSet<PerfilPorPermiso> PerfilPorPermisos { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<Productos> Productos { get; set; }

    public virtual DbSet<ProductosLote> ProductosLotes { get; set; }

    public virtual DbSet<SalidasInventarioDetalle> SalidasInventarioDetalles { get; set; }

    public virtual DbSet<Salidasinventario> Salidasinventarios { get; set; }

    public virtual DbSet<Sucursale> Sucursales { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EmpleadoMap());
        modelBuilder.ApplyConfiguration(new EstadoMap());
        modelBuilder.ApplyConfiguration(new PerfilMap());
        modelBuilder.ApplyConfiguration(new PerfilPorPermisoMap());
        modelBuilder.ApplyConfiguration(new PermisoMap());
        modelBuilder.ApplyConfiguration(new ProductoMap());
        modelBuilder.ApplyConfiguration(new ProductosLoteMap());
        modelBuilder.ApplyConfiguration(new SalidaInventarioDetalleMap());
        modelBuilder.ApplyConfiguration(new SalidaInventarioMap());
  

        modelBuilder.Entity<Sucursale>(entity =>
        {
            entity.HasKey(e => e.SucursalId).HasName("PK__Sucursal__6CB482E1C6BF8EB4");

            entity.Property(e => e.SucursalId).ValueGeneratedNever();
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuarios__2B3DE7B830543216");

            entity.HasIndex(e => e.Usuario, "UQ__Usuarios__E3237CF772EB816B").IsUnique();

            entity.Property(e => e.UsuarioId).ValueGeneratedNever();
            entity.Property(e => e.Clave)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Usuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Usuario");

            entity.HasOne(d => d.Empleado).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.EmpleadoId)
                .HasConstraintName("FK__Usuarios__Emplea__214BF109");

            entity.HasOne(d => d.Perfil).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.PerfilId)
                .HasConstraintName("FK__Usuarios__Perfil__308E3499");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
