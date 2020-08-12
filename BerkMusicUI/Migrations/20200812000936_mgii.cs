using Microsoft.EntityFrameworkCore.Migrations;

namespace BerkMusicUI.Migrations
{
    public partial class mgii : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LayoutDetails_FullLayoutID",
                table: "LayoutDetails");

            migrationBuilder.CreateIndex(
                name: "IX_LayoutDetails_FullLayoutID",
                table: "LayoutDetails",
                column: "FullLayoutID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LayoutDetails_FullLayoutID",
                table: "LayoutDetails");

            migrationBuilder.CreateIndex(
                name: "IX_LayoutDetails_FullLayoutID",
                table: "LayoutDetails",
                column: "FullLayoutID");
        }
    }
}
