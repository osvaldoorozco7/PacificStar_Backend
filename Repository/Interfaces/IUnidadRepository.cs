using PacificStarBackend.Models;

namespace PacificStarBackend.Repository.Interfaces
{
    public interface IUnidadRepository
    {
        Task<List<Unidad>> GetAllAsync();
        Task<Unidad> GetByIdAsync(int id);
        Task ActualizarAsync(Unidad unidad);
    }
}
