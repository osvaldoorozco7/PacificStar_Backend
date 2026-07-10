using PacificStarBackend.DTO.Responses;
using PacificStarBackend.Models;

namespace PacificStarBackend.Service
{
    public interface IBitacoraService
    {
        Task<List<BitacoraResponse>> ObtenerTodas();

        Task<Bitacora?> ObtenerPorId(int id);

        Task<Bitacora> Crear(Bitacora bitacora);

        Task<bool> Actualizar(int id, Bitacora bitacora);

        Task<bool> Eliminar(int id);
    }
}