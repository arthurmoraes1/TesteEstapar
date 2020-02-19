using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteEstapar.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carros",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Modelo = table.Column<string>(type: "varchar(50)", nullable: false),
                    Placa = table.Column<string>(type: "varchar(7)", nullable: false),
                    Marca = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manobristas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    Cpf = table.Column<string>(type: "varchar(11)", nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manobristas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResponsaveisManobras",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ManobristaId = table.Column<Guid>(nullable: false),
                    CarroId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponsaveisManobras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResponsaveisManobras_Carros_CarroId",
                        column: x => x.CarroId,
                        principalTable: "Carros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResponsaveisManobras_Manobristas_ManobristaId",
                        column: x => x.ManobristaId,
                        principalTable: "Manobristas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResponsaveisManobras_CarroId",
                table: "ResponsaveisManobras",
                column: "CarroId");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsaveisManobras_ManobristaId",
                table: "ResponsaveisManobras",
                column: "ManobristaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResponsaveisManobras");

            migrationBuilder.DropTable(
                name: "Carros");

            migrationBuilder.DropTable(
                name: "Manobristas");
        }
    }
}
