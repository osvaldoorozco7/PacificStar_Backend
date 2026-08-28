using PacificStarBackend.DTO.Responses;
using PacificStarBackend.Models;
using PacificStarBackend.Repository;
using PacificStarBackend.Repository.Interfaces;

namespace PacificStarBackend.Service
{
    public class BitacoraService : IBitacoraService
    {
        private readonly IBitacoraRepository _repository;

        public BitacoraService(IBitacoraRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<BitacoraResponse>> ObtenerTodas()
        {
            var bitacoras = await _repository.GetAllAsync();

            return bitacoras.Select(b => new BitacoraResponse
            {
                Id = b.Id,
                Fecha = b.Fecha,
                NumeroUnidad = b.NumeroUnidad,
                HorasMotor = b.HorasMotor,
                NivelCombustible = b.NivelCombustible,
                HoraEncendido = b.HoraEncendido,
                TempInicial = b.TempInicial,
                TempFinal = b.TempFinal
            }).ToList();
        }

        public async Task<Bitacora?> ObtenerPorId(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Bitacora> Crear(Bitacora bitacora)
        {
            bitacora.Fecha = DateTime.Now;
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
            existente.TempInicial = bitacora.TempInicial;
            existente.TempFinal = bitacora.TempFinal;

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
