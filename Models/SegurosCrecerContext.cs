using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SegurosCrecerAPI.Models;

public partial class SegurosCrecerContext : DbContext
{
    public SegurosCrecerContext()
    {
    }

    public SegurosCrecerContext(DbContextOptions<SegurosCrecerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Ramo> Ramos { get; set; }

    public virtual DbSet<Tasa> Tasas { get; set; }

    public virtual DbSet<TipoRamo> TipoRamos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-LKJ3L4T\\SQLEXPRESS;Initial Catalog=SegurosCrecer;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Producto__3214EC074D7EE626");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Ramo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ramos__3214EC075C3F64D2");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.TipoRamo).WithMany(p => p.Ramos)
                .HasForeignKey(d => d.TipoRamoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ramos__TipoRamoI__3F466844");
        });

        modelBuilder.Entity<Tasa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tasas__3214EC07014E49A8");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Tasa1)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Tasa");

        });

        modelBuilder.Entity<TipoRamo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TipoRamo__3214EC07D271C00F");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
