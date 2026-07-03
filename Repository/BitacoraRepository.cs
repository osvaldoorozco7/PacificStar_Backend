using Microsoft.EntityFrameworkCore;
using PacificStarBackend.Data;
using PacificStarBackend.Models;

namespace PacificStarBackend.Repository
{
    public class BitacoraRepository : IBitacoraRepository
    {
        private readonly PacificStarDbContext _context;

        public BitacoraRepository(PacificStarDbContext context)
        {
            _context = context;
        }

        public async Task<List<Bitacora>> GetAllAsync()
        {
            return await _context.Bitacoras
                .Include(b => b.Unidad)
                .ToListAsync();
        }

        public async Task<Bitacora?> GetByIdAsync(int id)
        {
            return await _context.Bitacoras
                .Include(b => b.Unidad)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Bitacora> AddAsync(Bitacora bitacora)
        {
            _context.Bitacoras.Add(bitacora);

            await _context.SaveChangesAsync();

            return bitacora;
        }

        public async Task UpdateAsync(Bitacora bitacora)
        {
            _context.Bitacoras.Update(bitacora);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var bitacora = await _context.Bitacoras.FindAsync(id);

            if (bitacora == null)
                return;

            _context.Bitacoras.Remove(bitacora);

            await _context.SaveChangesAsync();
        }
    }
}
