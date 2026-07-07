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
            modelBuilder.Entity<Unidad>()
                .HasKey(u => u.NumeroUnidad);

            modelBuilder.Entity<Bitacora>()
                .HasOne(b => b.Unidad)
                .WithMany(u => u.Bitacoras)
                .HasForeignKey(b => b.NumeroUnidad);
        }
    }
}
