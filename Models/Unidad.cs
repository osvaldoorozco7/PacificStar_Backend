using System;
using System.Collections.Generic;

namespace PacificStarBackend.Models;

public partial class Unidad
{
    public int NumeroUnidad { get; set; }

    public int? HorasMotor { get; set; }

    public virtual ICollection<Bitacora> Bitacoras { get; set; } = new List<Bitacora>();

}
