using PacificStarBackend.Models;

namespace PacificStarBackend.Repository
{
    public interface IBitacoraRepository
    {
        Task<List<Bitacora>> GetAllAsync();

        Task<Bitacora?> GetByIdAsync(int id);

        Task<Bitacora> AddAsync(Bitacora bitacora);

        Task UpdateAsync(Bitacora bitacora);

        Task DeleteAsync(int id);
    }
}