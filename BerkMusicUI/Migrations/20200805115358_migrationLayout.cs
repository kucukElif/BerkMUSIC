using Microsoft.EntityFrameworkCore.Migrations;

namespace BerkMusicUI.Migrations
{
    public partial class migrationLayout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MainDescription",
                table: "Layouts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MainImagePath",
                table: "Layouts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MainTitle",
                table: "Layouts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainDescription",
                table: "Layouts");

            migrationBuilder.DropColumn(
                name: "MainImagePath",
                table: "Layouts");

            migrationBuilder.DropColumn(
                name: "MainTitle",
                table: "Layouts");
        }
    }
}
