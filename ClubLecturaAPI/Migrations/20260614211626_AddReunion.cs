using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClubLecturaAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddReunion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reuniones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Lugar = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Tema = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LibroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reuniones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reuniones_Libros_LibroId",
                        column: x => x.LibroId,
                        principalTable: "Libros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reuniones_LibroId",
                table: "Reuniones",
                column: "LibroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reuniones");
        }
    }
}
