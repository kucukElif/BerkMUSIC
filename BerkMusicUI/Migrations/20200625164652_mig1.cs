using Microsoft.EntityFrameworkCore.Migrations;

namespace BerkMusicUI.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Specifications",
                table: "Identities");

            migrationBuilder.AddColumn<string>(
                name: "Specifications1",
                table: "Identities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Specifications2",
                table: "Identities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Specifications3",
                table: "Identities",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Specifications1",
                table: "Identities");

            migrationBuilder.DropColumn(
                name: "Specifications2",
                table: "Identities");

            migrationBuilder.DropColumn(
                name: "Specifications3",
                table: "Identities");

            migrationBuilder.AddColumn<string>(
                name: "Specifications",
                table: "Identities",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
