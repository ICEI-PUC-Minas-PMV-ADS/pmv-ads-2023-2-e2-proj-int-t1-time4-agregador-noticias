using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tech_news.Migrations
{
    public partial class M06CreateNoticiaUsuarioDependency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Noticias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Noticias_UsuarioId",
                table: "Noticias",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Noticias_Usuarios_UsuarioId",
                table: "Noticias",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Noticias_Usuarios_UsuarioId",
                table: "Noticias");

            migrationBuilder.DropIndex(
                name: "IX_Noticias_UsuarioId",
                table: "Noticias");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Noticias");
        }
    }
}
