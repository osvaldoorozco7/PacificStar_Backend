using Microsoft.AspNetCore.Mvc;
using PacificStarBackend.DTO.Request;
using PacificStarBackend.Models;
using PacificStarBackend.Service;

namespace PacificStarBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BitacoraController : ControllerBase
    {
        private readonly IBitacoraService _service;

        public BitacoraController(IBitacoraService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.ObtenerTodas());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var bitacora = await _service.ObtenerPorId(id);

            if (bitacora == null)
                return NotFound();

            return Ok(bitacora);
        }

        [HttpPost("{saveBitacora}")]
        public async Task<IActionResult> Post(CrearBitacoraRequest BitacoraDTO)
        {
            var bitacora = new Bitacora
            {
                NumeroUnidad = BitacoraDTO.NumeroUnidad,
                HorasMotor = BitacoraDTO.HorasMotor,
                NivelCombustible = BitacoraDTO.NivelCombustible,
                HoraEncendido = BitacoraDTO.HoraEncendido,
                TempInicial = BitacoraDTO.TempInicial,
                TempFinal = BitacoraDTO.TempFinal,
                Fecha = BitacoraDTO.Fecha
            };

            var resultado = await _service.Crear(bitacora);

            return Ok(resultado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Bitacora bitacora)
        {
            var actualizado = await _service.Actualizar(id, bitacora);

            if (!actualizado)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _service.Eliminar(id);

            if (!eliminado)
                return NotFound();

            return NoContent();
        }
    }
}