using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PacificStarBackend;

public partial class PacificStarDbContext : DbContext
{
    public PacificStarDbContext()
    {
    }

    public PacificStarDbContext(DbContextOptions<PacificStarDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bitacora> Bitacoras { get; set; }

    public virtual DbSet<Unidad> Unidads { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=PacificStarDB;Integrated Security=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bitacora>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__bitacora__3213E83F7ABCC4B0");

            entity.ToTable("bitacora");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.HoraEncendido).HasColumnName("hora_encendido");
            entity.Property(e => e.NivelCombustible)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("nivel_combustible");
            entity.Property(e => e.NumeroUnidad).HasColumnName("numero_unidad");
            entity.Property(e => e.TemperaturaFinal)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("temperatura_final");
            entity.Property(e => e.TemperaturaInicial)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("temperatura_inicial");

            entity.HasOne(d => d.NumeroUnidadNavigation).WithMany(p => p.Bitacoras)
                .HasForeignKey(d => d.NumeroUnidad)
                .HasConstraintName("fk_numero_unidad");
        });

        modelBuilder.Entity<Unidad>(entity =>
        {
            entity.HasKey(e => e.NumeroUnidad).HasName("PK__unidad__F6F23C16DD56963D");

            entity.ToTable("unidad");

            entity.Property(e => e.NumeroUnidad)
                .ValueGeneratedNever()
                .HasColumnName("numero_unidad");
            entity.Property(e => e.HorasMotor).HasColumnName("horas_motor");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
