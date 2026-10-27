namespace PacificStarBackend.DTO
{
    public class ServicioMotor
    {
        public int NumeroUnidad { get; set; }
        public int HorasServicio { get; set; }
        public DateOnly FechaServicio { get; set; } = new DateOnly();

    }
}
