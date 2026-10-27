using Microsoft.EntityFrameworkCore;
using PacificStarBackend.Data;
using PacificStarBackend.DTO;
using PacificStarBackend.Models;
using PacificStarBackend.Repository.Interfaces;

namespace PacificStarBackend.Repository
{
    public class UnidadRepository : IUnidadRepository
    {
        private readonly PacificStarDbContext _context;

        public UnidadRepository(PacificStarDbContext context)
        {
            _context = context;
        }

        public async Task<List<Unidad>> GetAllAsync()
        {
            return await _context.Unidades
                .ToListAsync();
        }

        public async Task<Unidad?> GetByIdAsync(int id)
        {
            return await _context.Unidades
                .FirstOrDefaultAsync(u => u.NumeroUnidad == id);
        }

        public async Task ActualizarAsync(Unidad unidad)
        {
            _context.Unidades.Update(unidad);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AgregarServicioAsync(ServicioMotor servicio)
        {
            var unidad = await _context.Unidades.FirstOrDefaultAsync(u => u.NumeroUnidad == servicio.NumeroUnidad);
            if (unidad == null)
                return false;
            unidad.UltimoServicio = servicio.HorasServicio;
            unidad.FechaUltimoServicio = servicio.FechaServicio;
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
