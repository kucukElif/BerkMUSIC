using Microsoft.EntityFrameworkCore.Migrations;

namespace BerkMusicUI.Migrations
{
    public partial class miger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LayoutDetails_LayoutID",
                table: "LayoutDetails");

            migrationBuilder.CreateIndex(
                name: "IX_LayoutDetails_LayoutID",
                table: "LayoutDetails",
                column: "LayoutID",
                unique: true,
                filter: "[LayoutID] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LayoutDetails_LayoutID",
                table: "LayoutDetails");

            migrationBuilder.CreateIndex(
                name: "IX_LayoutDetails_LayoutID",
                table: "LayoutDetails",
                column: "LayoutID");
        }
    }
}
