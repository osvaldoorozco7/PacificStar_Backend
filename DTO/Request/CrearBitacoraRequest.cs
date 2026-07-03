using System.ComponentModel.DataAnnotations;

namespace PacificStarBackend.DTO.Request
{
    public class CrearBitacoraRequest
    {
        [Required]
        public int NumeroUnidad { get; set; }
        [Range(-30, 40)]
        public decimal TempInicial { get; set; }
    }
}
