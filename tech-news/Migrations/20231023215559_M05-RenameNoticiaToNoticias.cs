using Microsoft.EntityFrameworkCore.Migrations;
using Tech_news.Models;

#nullable disable

namespace Tech_news.Migrations
{
    public partial class M05RenameNoticiaToNoticias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Noticia",
                newName: "Noticias"
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Noticias",
                newName: "Noticia"
                );
        }
    }
}
