 using Microsoft.EntityFrameworkCore;
using PacificStarBackend.Models;

namespace PacificStarBackend.Data
{
    public class PacificStarDbContext : DbContext
    {
        public PacificStarDbContext(DbContextOptions<PacificStarDbContext> options)
            : base(options)
        {
        }

        public DbSet<Unidad> Unidades { get; set; }

        public DbSet<Bitacora> Bitacoras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Unidad>(entity =>
            {
                entity.HasKey(u => u.NumeroUnidad);

                entity.ToTable("unidades");

                entity.Property(u => u.NumeroUnidad)
                    .HasColumnName("numero_unidad");
            });


            modelBuilder.Entity<Bitacora>(entity =>
            {
                entity.ToTable("bitacoras");

                entity.HasKey(b => b.Id);

                entity.Property(b => b.Id)
                    .UseIdentityColumn(1, 1);


                entity.Property(b => b.Fecha)
                    .HasColumnType("datetime2");


                entity.Property(b => b.HoraEncendido)
                    .HasColumnType("datetime2");


                entity.Property(b => b.TempInicial)
                    .HasPrecision(5, 2);


                entity.Property(b => b.TempFinal)
                    .HasPrecision(5, 2);


                entity.Property(b => b.NivelCombustible)
                    .HasPrecision(5, 2);


                entity.HasOne(b => b.Unidad)
                    .WithMany(u => u.Bitacoras)
                    .HasForeignKey(b => b.NumeroUnidad);
            });
        }
    }
}
