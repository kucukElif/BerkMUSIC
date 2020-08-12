using Microsoft.EntityFrameworkCore.Migrations;

namespace BerkMusicUI.Migrations
{
    public partial class migrationFullPots : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullDescription",
                table: "Layouts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullImagePath",
                table: "Layouts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullTitle",
                table: "Layouts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullDescription",
                table: "Layouts");

            migrationBuilder.DropColumn(
                name: "FullImagePath",
                table: "Layouts");

            migrationBuilder.DropColumn(
                name: "FullTitle",
                table: "Layouts");
        }
    }
}
