using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Equitel.Models;

public partial class EquitelContext : DbContext
{
    public EquitelContext()
    {
    }

    public EquitelContext(DbContextOptions<EquitelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DetalleVenta> DetalleVentas { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedore> Proveedores { get; set; }

    public virtual DbSet<RegistroAuditorium> RegistroAuditoria { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DetalleVenta>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Idproducto).HasColumnName("IDProducto");
            entity.Property(e => e.Idventa).HasColumnName("IDVenta");
            entity.Property(e => e.PrecioVenta).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdproductoNavigation).WithMany()
                .HasForeignKey(d => d.Idproducto)
                .HasConstraintName("FK__DetalleVe__IDPro__403A8C7D");

            entity.HasOne(d => d.IdventaNavigation).WithMany()
                .HasForeignKey(d => d.Idventa)
                .HasConstraintName("FK__DetalleVe__IDVen__412EB0B6");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Producto__3214EC2754520231");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descripcion).HasMaxLength(100);
            entity.Property(e => e.Modelo).HasMaxLength(50);
            entity.Property(e => e.ValorVenta).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Proveedore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Proveedo__3214EC27250622CA");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Contacto).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<RegistroAuditorium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Registro__3214EC27B1563522");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AccionRealizada).HasMaxLength(100);
            entity.Property(e => e.FechaHora).HasColumnType("datetime");
            entity.Property(e => e.Usuario).HasMaxLength(50);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__3214EC27A3DF341E");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Rol).HasMaxLength(50);
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ventas__3214EC272D311EBC");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FechaVenta).HasColumnType("datetime");
            entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.Idusuario)
                .HasConstraintName("FK__Ventas__IDUsuari__4222D4EF");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
