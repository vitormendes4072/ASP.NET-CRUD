using Microsoft.EntityFrameworkCore.Migrations;

namespace Fiap.Aula03.Web.Exemplo01.Migrations
{
    public partial class MusicaAlbumOpcional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Musica_Tbl_Album_AlbumId",
                table: "Tbl_Musica");

            migrationBuilder.AlterColumn<int>(
                name: "AlbumId",
                table: "Tbl_Musica",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Musica_Tbl_Album_AlbumId",
                table: "Tbl_Musica",
                column: "AlbumId",
                principalTable: "Tbl_Album",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Musica_Tbl_Album_AlbumId",
                table: "Tbl_Musica");

            migrationBuilder.AlterColumn<int>(
                name: "AlbumId",
                table: "Tbl_Musica",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Musica_Tbl_Album_AlbumId",
                table: "Tbl_Musica",
                column: "AlbumId",
                principalTable: "Tbl_Album",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}