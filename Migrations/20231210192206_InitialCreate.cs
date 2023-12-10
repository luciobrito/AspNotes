using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNotes.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pastas",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pastas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    senha = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Notas",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    titulo = table.Column<string>(type: "text", nullable: false),
                    corpo = table.Column<string>(type: "text", nullable: false),
                    pastaId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Notas_Pastas_pastaId",
                        column: x => x.pastaId,
                        principalTable: "Pastas",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notas_pastaId",
                table: "Notas",
                column: "pastaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Pastas");
        }
    }
}
