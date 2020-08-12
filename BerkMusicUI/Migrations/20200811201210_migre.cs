using Microsoft.EntityFrameworkCore.Migrations;

namespace BerkMusicUI.Migrations
{
    public partial class migre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "LayoutDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "LayoutDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "LayoutDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "LayoutDetails");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "LayoutDetails");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "LayoutDetails");
        }
    }
}
