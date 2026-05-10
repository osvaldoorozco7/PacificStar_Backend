using System.ComponentModel;

namespace PacificStarBackend.Enums
{
    public enum NivelCombustible
    {
        [Description("Vacío")]
        Vacio,
        [Description("1/8")]
        UnOctavo,
        [Description("1/4")]
        UnCuarto,
        [Description("3/8")]
        TresOctavos,
        [Description("1/2")]
        UnMedio,
        [Description("5/8")]
        CincoOctavos,
        [Description("3/4")]
        TresCuartos,
        [Description("7/8")]
        SieteOctavos,
        [Description("Lleno")]
        Lleno,
    }
}
