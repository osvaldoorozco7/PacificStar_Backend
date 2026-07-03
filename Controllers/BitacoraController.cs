using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        public async Task<IActionResult> Post(Bitacora bitacora)
        {
            var nueva = await _service.Crear(bitacora);

            return CreatedAtAction(nameof(Get), new { id = nueva.Id }, nueva);
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