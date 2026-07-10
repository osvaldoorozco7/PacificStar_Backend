namespace PacificStarBackend.DTO.Responses
{
    public class BitacoraResponse
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public int NumeroUnidad { get; set; }

        public decimal NivelCombustible { get; set; }

        public DateTime HoraEncendido { get; set; }

        public decimal TempInicial { get; set; }

        public decimal TempFinal { get; set; }

    }
}
