using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PacificStarBackend.Service;
using PacificStarBackend.Service.Interfaces;

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


        [HttpPost("addBitacora")]
        public IActionResult Add(Bitacora bitacora)
        {
            return Ok(bitacora);
        }

        [HttpDelete("deleteBitacora/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();    
        }
}
