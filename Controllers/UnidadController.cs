using Microsoft.AspNetCore.Mvc;
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
    }
}
