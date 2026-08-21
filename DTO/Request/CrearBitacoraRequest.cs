using System.ComponentModel.DataAnnotations;

namespace PacificStarBackend.DTO.Request
{
    public class CrearBitacoraRequest
    {
        [Required]
        public int NumeroUnidad { get; set; }
        public DateTime Fecha {  get; set; }
        public decimal NivelCombustible { get; set; }
        public DateTime HoraEncendido { get; set; }
        [Range(-30, 40)]  
        public decimal TempInicial { get; set; }
        public decimal TempFinal { get; set; }
    }
}
