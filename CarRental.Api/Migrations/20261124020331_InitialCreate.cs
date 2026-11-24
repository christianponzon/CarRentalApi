using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Api.Migrations;

/// <inheritdoc />
public partial class _20261124020331_InitialCreate : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Auto",
            columns: table => new
            {
                id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Marca = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                Modelo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                Precio = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: false),
                Year = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Auto", x => x.id);
            });

        migrationBuilder.CreateTable(
            name: "Usuario",
            columns: table => new
            {
                id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                NombreUsuario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                Correo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Usuario", x => x.id);
            });

        migrationBuilder.CreateTable(
            name: "Alquiler",
            columns: table => new
            {
                id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                UsuarioId = table.Column<int>(type: "int", nullable: false),
                AutoId = table.Column<int>(type: "int", nullable: false),
                FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Alquiler", x => x.id);
                table.ForeignKey(
                    name: "FK_Alquiler_Auto_AutoId",
                    column: x => x.AutoId,
                    principalTable: "Auto",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Alquiler_Usuario_UsuarioId",
                    column: x => x.UsuarioId,
                    principalTable: "Usuario",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Alquiler_AutoId",
            table: "Alquiler",
            column: "AutoId");

        migrationBuilder.CreateIndex(
            name: "IX_Alquiler_UsuarioId",
            table: "Alquiler",
            column: "UsuarioId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Alquiler");

        migrationBuilder.DropTable(
            name: "Auto");

        migrationBuilder.DropTable(
            name: "Usuario");
    }
}
