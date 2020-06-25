using Microsoft.EntityFrameworkCore.Migrations;

namespace BerkMusicUI.Migrations
{
    public partial class mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CostImagePath",
                table: "HomeSettings");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "HomeSettings");

            migrationBuilder.AddColumn<string>(
                name: "Cost1ImagePath",
                table: "HomeSettings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cost2ImagePath",
                table: "HomeSettings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cost3ImagePath",
                table: "HomeSettings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nav1ImagePath",
                table: "HomeSettings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nav2ImagePath",
                table: "HomeSettings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nav3ImagePath",
                table: "HomeSettings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost1ImagePath",
                table: "HomeSettings");

            migrationBuilder.DropColumn(
                name: "Cost2ImagePath",
                table: "HomeSettings");

            migrationBuilder.DropColumn(
                name: "Cost3ImagePath",
                table: "HomeSettings");

            migrationBuilder.DropColumn(
                name: "Nav1ImagePath",
                table: "HomeSettings");

            migrationBuilder.DropColumn(
                name: "Nav2ImagePath",
                table: "HomeSettings");

            migrationBuilder.DropColumn(
                name: "Nav3ImagePath",
                table: "HomeSettings");

            migrationBuilder.AddColumn<string>(
                name: "CostImagePath",
                table: "HomeSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "HomeSettings",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
