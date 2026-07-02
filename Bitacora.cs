using PacificStarBackend.Models;
using System;
using System.Collections.Generic;

namespace PacificStarBackend;

public partial class Bitacora
{
    public int Id { get; set; }

    public DateOnly? Fecha { get; set; }

    public int? NumeroUnidad { get; set; }

    public decimal? TemperaturaInicial { get; set; }

    public decimal? TemperaturaFinal { get; set; }

    public DateOnly? HoraEncendido { get; set; }

    public decimal? NivelCombustible { get; set; }

    public virtual Unidad? Unidad { get; set; }
}
