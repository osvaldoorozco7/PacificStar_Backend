using PacificStarBackend.DTO;
using PacificStarBackend.Models;

namespace PacificStarBackend.Service
{
    public interface IUnidadService
    {
        Task<List<Unidad>> ObtenerTodas();
        Task<bool> Actualizar(int id, Unidad unidad);
        Task<bool> AgregarServicio(ServicioMotor servicio);
    }
}
