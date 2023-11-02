using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tech_news.Migrations
{
    public partial class M07CreateDataPublicacaoInNoticia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataPublicacao",
                table: "Noticias",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(System.DateTime.Now.Ticks, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataPublicacao",
                table: "Noticias");
        }
    }
}
