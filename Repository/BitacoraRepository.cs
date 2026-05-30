using Microsoft.EntityFrameworkCore;
using PacificStarBackend.Repository.Interfaces;

namespace PacificStarBackend.Repository
{
    public class BitacoraRepository : IBitacoraRepository
    {
        private readonly PacificStarDbContext _context;

        public BitacoraRepository(PacificStarDbContext context)
        {
            _context = context;
        }

        public async Task<List<Bitacora>> GetAll()
        {
            return await _context.Bitacoras.ToListAsync();
        }
    }
}
