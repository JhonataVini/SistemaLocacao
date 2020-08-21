using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaLocacao.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    IdCliente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CPF = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Filmes",
                columns: table => new
                {
                    IdFilme = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmes", x => x.IdFilme);
                });

            migrationBuilder.CreateTable(
                name: "Locacoes",
                columns: table => new
                {
                    IdLocacao = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataLocacao = table.Column<DateTime>(nullable: false),
                    DataEntrega = table.Column<DateTime>(nullable: false),
                    DataDevolucao = table.Column<DateTime>(nullable: false),
                    IdFilme = table.Column<int>(nullable: false),
                    IdCliente = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locacoes", x => x.IdLocacao);
                    table.ForeignKey(
                        name: "FK_Locacoes_clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Locacoes_Filmes_IdFilme",
                        column: x => x.IdFilme,
                        principalTable: "Filmes",
                        principalColumn: "IdFilme",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locacoes_IdCliente",
                table: "Locacoes",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Locacoes_IdFilme",
                table: "Locacoes",
                column: "IdFilme");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locacoes");

            migrationBuilder.DropTable(
                name: "clientes");

            migrationBuilder.DropTable(
                name: "Filmes");
        }
    }
}
