using PacificStarBackend.Models;

namespace PacificStarBackend.Service
{
    public interface IUnidadService
    {
        Task<List<Unidad>> ObtenerTodas();

        Task<bool> Actualizar(int id, Unidad unidad);
    }
}
