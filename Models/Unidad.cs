using PacificStarBackend;

namespace PacificStarBackend.Models;

public partial class Unidad
{
    public int NumeroUnidad { get; set; }
    public int? HorasMotor { get; set; }

    public virtual IEnumerable<Bitacora> Bitacoras { get; set; } = new List<Bitacora>();
}