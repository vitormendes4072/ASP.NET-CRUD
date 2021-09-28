using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fiap.Aula03.Web.Exemplo01.Migrations
{
    public partial class BancoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Musica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Dt_Lancamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duracao = table.Column<float>(type: "real", nullable: false),
                    Explicita = table.Column<bool>(type: "bit", nullable: false),
                    Genero = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Musica", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Musica");
        }
    }
}
