﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tech_news.Migrations
{
    public partial class M08CreateTagInNoticia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Tag",
                table: "Noticias",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tag",
                table: "Noticias");
        }
    }
}
