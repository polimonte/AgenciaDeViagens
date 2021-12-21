using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RGBViagens.Migrations
{
    public partial class bancoRGB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contato",
                columns: table => new
                {
                    ID_Contato = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mensagem = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contato", x => x.ID_Contato);
                });

            migrationBuilder.CreateTable(
                name: "Destinos",
                columns: table => new
                {
                    ID_Destinos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_lugar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco_Promoção = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinos", x => x.ID_Destinos);
                });

            migrationBuilder.CreateTable(
                name: "ComprarDestinos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Origem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ID_Destinos = table.Column<int>(type: "int", nullable: false),
                    Ida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Volta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    N_Passageiros = table.Column<int>(type: "int", nullable: false),
                    Classe = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComprarDestinos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ComprarDestinos_Destinos_ID_Destinos",
                        column: x => x.ID_Destinos,
                        principalTable: "Destinos",
                        principalColumn: "ID_Destinos",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComprarDestinos_ID_Destinos",
                table: "ComprarDestinos",
                column: "ID_Destinos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComprarDestinos");

            migrationBuilder.DropTable(
                name: "Contato");

            migrationBuilder.DropTable(
                name: "Destinos");
        }
    }
}
