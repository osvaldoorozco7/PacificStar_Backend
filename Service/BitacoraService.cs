using PacificStarBackend.Models;
using PacificStarBackend.Repository;

namespace PacificStarBackend.Service
{
    public class BitacoraService : IBitacoraService
    {
        private readonly IBitacoraRepository _repository;

        public BitacoraService(IBitacoraRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Bitacora>> ObtenerTodas()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Bitacora?> ObtenerPorId(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Bitacora> Crear(Bitacora bitacora)
        {
            return await _repository.AddAsync(bitacora);
        }

        public async Task<bool> Actualizar(int id, Bitacora bitacora)
        {
            var existente = await _repository.GetByIdAsync(id);

            if (existente == null)
                return false;

            existente.Fecha = bitacora.Fecha;
            existente.NivelCombustible = bitacora.NivelCombustible;
            existente.HoraEncendido = bitacora.HoraEncendido;
            existente.TemperaturaInicial = bitacora.TemperaturaInicial;
            existente.TemperaturaFinal = bitacora.TemperaturaFinal;

            await _repository.UpdateAsync(existente);

            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var existente = await _repository.GetByIdAsync(id);

            if (existente == null)
                return false;

            await _repository.DeleteAsync(id);

            return true;
        }
    }
}
