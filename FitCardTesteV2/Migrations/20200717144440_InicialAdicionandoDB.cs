using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitCardTesteV2.Migrations
{
    public partial class InicialAdicionandoDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estabelecimentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RazaoSocial = table.Column<string>(nullable: false),
                    NomeFantasia = table.Column<string>(nullable: true),
                    CNPJ = table.Column<string>(maxLength: 20, nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Endereco = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(maxLength: 20, nullable: true),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    Categoria = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Agencia = table.Column<string>(maxLength: 5, nullable: true),
                    Conta = table.Column<string>(maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estabelecimentos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estabelecimentos");
        }
    }
}
