using Microsoft.EntityFrameworkCore.Migrations;

namespace BerkMusicUI.Migrations
{
    public partial class LayoutClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MainDescription",
                table: "Layouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MainImagePath",
                table: "Layouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MainTitle",
                table: "Layouts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
