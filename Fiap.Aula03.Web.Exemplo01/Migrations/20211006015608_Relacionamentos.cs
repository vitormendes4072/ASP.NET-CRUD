using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fiap.Aula03.Web.Exemplo01.Migrations
{
    public partial class Relacionamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AlbumId",
                table: "Tbl_Musica",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Tbl_Album",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Dt_Lancamento = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Album", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logradouro = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Endereco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Artista",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Genero = table.Column<int>(type: "int", nullable: false),
                    Dt_Nascimento = table.Column<DateTime>(type: "Date", nullable: false),
                    EnderecoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Artista", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Artista_Tbl_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Tbl_Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Musica_Artista",
                columns: table => new
                {
                    MusicaId = table.Column<int>(type: "int", nullable: false),
                    ArtistaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Musica_Artista", x => new { x.ArtistaId, x.MusicaId });
                    table.ForeignKey(
                        name: "FK_Tbl_Musica_Artista_Tbl_Artista_ArtistaId",
                        column: x => x.ArtistaId,
                        principalTable: "Tbl_Artista",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Musica_Artista_Tbl_Musica_MusicaId",
                        column: x => x.MusicaId,
                        principalTable: "Tbl_Musica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Musica_AlbumId",
                table: "Tbl_Musica",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Artista_EnderecoId",
                table: "Tbl_Artista",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Musica_Artista_MusicaId",
                table: "Tbl_Musica_Artista",
                column: "MusicaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Musica_Tbl_Album_AlbumId",
                table: "Tbl_Musica",
                column: "AlbumId",
                principalTable: "Tbl_Album",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Musica_Tbl_Album_AlbumId",
                table: "Tbl_Musica");

            migrationBuilder.DropTable(
                name: "Tbl_Album");

            migrationBuilder.DropTable(
                name: "Tbl_Musica_Artista");

            migrationBuilder.DropTable(
                name: "Tbl_Artista");

            migrationBuilder.DropTable(
                name: "Tbl_Endereco");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_Musica_AlbumId",
                table: "Tbl_Musica");

            migrationBuilder.DropColumn(
                name: "AlbumId",
                table: "Tbl_Musica");
        }
    }
}