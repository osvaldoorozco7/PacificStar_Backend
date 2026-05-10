using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PacificStarBackend.Repository;
using PacificStarBackend.Service;

namespace PacificStarBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BitacoraController : ControllerBase
    {
        private readonly IBitacoraService _bitacoraService;

        public BitacoraController(IBitacoraService bitacoraService)
        {
            _bitacoraService = bitacoraService;
        }


        [HttpPost]
        public IActionResult Add(Bitacora bitacora)
        {
            return Ok(bitacora);
        }
    }
}
