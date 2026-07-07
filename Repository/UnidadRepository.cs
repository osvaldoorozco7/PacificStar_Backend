using Microsoft.EntityFrameworkCore;
using PacificStarBackend.Data;
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
    }
}
