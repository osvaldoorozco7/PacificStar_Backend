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

        public async Task<bool> Actualizar(int id, Unidad unidad)
        {
            var existente = await _repository.GetByIdAsync(id);

            if (existente == null) return false;

            existente.NumeroUnidad = unidad.NumeroUnidad;
            existente.HorasMotor = unidad.HorasMotor;
            existente.Modelo = unidad.Modelo;
            existente.Active = unidad.Active;

            await _repository.ActualizarAsync(existente);

            return true;
        }
    }
}
