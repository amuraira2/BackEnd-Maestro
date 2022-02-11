using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datos.Migrations
{
    public partial class ConfiguracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "catalogos");

            migrationBuilder.CreateTable(
                name: "Caseta",
                schema: "catalogos",
                columns: table => new
                {
                    CasetaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FechaAlta = table.Column<DateTime>(type: "datetime2", maxLength: 250, nullable: false),
                    FechaEdita = table.Column<DateTime>(type: "datetime2", maxLength: 15, nullable: false),
                    FechaElimina = table.Column<DateTime>(type: "datetime2", maxLength: 15, nullable: false),
                    Rfc = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    BActivo = table.Column<bool>(type: "bit", maxLength: 15, nullable: false),
                    CasetaId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caseta", x => x.CasetaId);
                    table.ForeignKey(
                        name: "FK_Caseta_Caseta_CasetaId1",
                        column: x => x.CasetaId1,
                        principalSchema: "catalogos",
                        principalTable: "Caseta",
                        principalColumn: "CasetaId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Caseta_CasetaId1",
                schema: "catalogos",
                table: "Caseta",
                column: "CasetaId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Caseta",
                schema: "catalogos");
        }
    }
}
