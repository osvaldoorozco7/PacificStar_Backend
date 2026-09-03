using Microsoft.AspNetCore.Mvc;
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
    }
}
