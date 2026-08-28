using System.ComponentModel.DataAnnotations.Schema;

namespace PacificStarBackend.Models
{
    public class Bitacora
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        [Column("numero_unidad")]
        public int NumeroUnidad { get; set; }
        [Column("horas_motor")]
        public  int HorasMotor { get; set; }

        [Column("nivel_combustible")]
        public decimal NivelCombustible { get; set; }

        [Column("hora_encendido")]
        public DateTime HoraEncendido { get; set; }

        [Column("temperatura_inicial")]
        public decimal TempInicial { get; set; }

        [Column("temperatura_final")]
        public decimal TempFinal { get; set; }
        public Unidad Unidad { get; set; } = null!;
    }
}