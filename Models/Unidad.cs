using PacificStarBackend;
using System.ComponentModel.DataAnnotations.Schema;

namespace PacificStarBackend.Models;

public partial class Unidad
{
    [Column("numero_unidad")]
    public int NumeroUnidad { get; set; }
    [Column("horas_motor")]
    public int? HorasMotor { get; set; }
    [Column("modelo")]
    public string? Modelo { get; set; }
    [Column("active")]
    public Boolean Active { get; set; }

    public virtual ICollection<Bitacora> Bitacoras { get; set; } = new List<Bitacora>();
}