using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PacificStarBackend.Migrations
{
    /// <inheritdoc />
    public partial class RemoveIdentityFromUnidad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "unidades",
                columns: table => new
                {
                    numero_unidad = table.Column<int>(type: "int", nullable: false),
                    horas_motor = table.Column<int>(type: "int", nullable: true),
                    modelo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unidades", x => x.numero_unidad);
                });

            migrationBuilder.CreateTable(
                name: "bitacoras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    numero_unidad = table.Column<int>(type: "int", nullable: false),
                    nivel_combustible = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    hora_encendido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    temperatura_inicial = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    temperatura_final = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bitacoras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bitacoras_unidades_numero_unidad",
                        column: x => x.numero_unidad,
                        principalTable: "unidades",
                        principalColumn: "numero_unidad",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bitacoras_numero_unidad",
                table: "bitacoras",
                column: "numero_unidad");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bitacoras");

            migrationBuilder.DropTable(
                name: "unidades");
        }
    }
}
