using PacificStarBackend.Models;
using PacificStarBackend.Repository.Interfaces;

namespace PacificStarBackend.Service
{
    public class UnidadService : IUnidadService
    {
        private readonly IUnidadRepository _repository;

        public UnidadService(IUnidadRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<Unidad>> ObtenerTodas()
        {
            return await _repository.GetAllAsync();
        }
    }
}
