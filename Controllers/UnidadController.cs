using Microsoft.AspNetCore.Mvc;
using PacificStarBackend.DTO;
using PacificStarBackend.Models;
using PacificStarBackend.Service;

namespace PacificStarBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UnidadController : ControllerBase
    {
        private readonly IUnidadService _unidadService;

        public UnidadController(IUnidadService service)
        {
            _unidadService = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _unidadService.ObtenerTodas());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Unidad unidad)
        {
            var actualizado = await _unidadService.Actualizar(id, unidad);
            return Ok(actualizado);
        }

        [HttpPost("{id}/servicio")]
        public async Task<IActionResult> AddService(ServicioMotor servicio)
        {
            if (servicio.HorasServicio <= 0)
                return BadRequest("Las horas de servicio deben ser mayores a 0.");

            var actualizado = await _unidadService.AgregarServicio(servicio);

            if (!actualizado)
                return NotFound($"No se encontró la unidad {servicio.NumeroUnidad}.");

            return Ok(new
            {
                mensaje = "Servicio agregado correctamente",
                numeroUnidad = servicio.NumeroUnidad,
                horasServicio = servicio.HorasServicio,
                fechaServicio = servicio.FechaServicio
            });
        }
    }
}
