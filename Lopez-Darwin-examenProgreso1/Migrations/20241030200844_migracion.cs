using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lopez_Darwin_examenProgreso1.Migrations
{
    /// <inheritdoc />
    public partial class migracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Celular",
                columns: table => new
                {
                    modelo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    año = table.Column<int>(type: "int", nullable: false),
                    precio = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Celular", x => x.modelo);
                });

            migrationBuilder.CreateTable(
                name: "Lopez",
                columns: table => new
                {
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    edad = table.Column<int>(type: "int", nullable: false),
                    EsEcuatoriano = table.Column<bool>(type: "bit", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    estatura = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    celularesmodelo = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lopez", x => x.nombre);
                    table.ForeignKey(
                        name: "FK_Lopez_Celular_celularesmodelo",
                        column: x => x.celularesmodelo,
                        principalTable: "Celular",
                        principalColumn: "modelo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lopez_celularesmodelo",
                table: "Lopez",
                column: "celularesmodelo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lopez");

            migrationBuilder.DropTable(
                name: "Celular");
        }
    }
}
