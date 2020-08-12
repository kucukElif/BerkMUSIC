using Microsoft.EntityFrameworkCore.Migrations;

namespace BerkMusicUI.Migrations
{
    public partial class migrationProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Description",
                table: "FullLayouts");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "FullLayouts");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "FullLayouts");

            migrationBuilder.AddColumn<string>(
                name: "FullDescription",
                table: "FullLayouts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullImagePath",
                table: "FullLayouts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullTitle",
                table: "FullLayouts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullDescription",
                table: "FullLayouts");

            migrationBuilder.DropColumn(
                name: "FullImagePath",
                table: "FullLayouts");

            migrationBuilder.DropColumn(
                name: "FullTitle",
                table: "FullLayouts");

            migrationBuilder.AddColumn<string>(
                name: "FullDescription",
                table: "Layouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullImagePath",
                table: "Layouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullTitle",
                table: "Layouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "FullLayouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "FullLayouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "FullLayouts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
