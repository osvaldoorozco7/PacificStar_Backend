using PacificStarBackend.Enums;

namespace PacificStarBackend.Models
{
    public class Bitacora
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int NumeroUnidad { get; set; }
        public NivelCombustible NivelCombustible { get; set; }
        public DateTime HoraEncendido  { get; set; }
        public decimal TempInicial { get; set; }
        public decimal TempPrimeraRevison { get; set; }
        public decimal TempSegundaRevision { get; set; }
        public decimal TempFinal { get; set; }

    }
}
