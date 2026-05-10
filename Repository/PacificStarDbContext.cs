using Microsoft.EntityFrameworkCore;
using PacificStarBackend.Models;
namespace PacificStarBackend.Repository
{
    public class PacificStarDbContext : DbContext
    {
        public PacificStarDbContext(DbContextOptions<PacificStarDbContext> options) : base(options)
        {
        }
        public DbSet<Unidad> Unidades { get; set; }
        public DbSet<Bitacora> Bitacoras { get; set; }
    }
}
