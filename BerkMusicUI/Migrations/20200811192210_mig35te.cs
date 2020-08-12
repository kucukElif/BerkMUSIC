using Microsoft.EntityFrameworkCore.Migrations;

namespace BerkMusicUI.Migrations
{
    public partial class mig35te : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LayoutDetails_FullLayoutID",
                table: "LayoutDetails");

            migrationBuilder.DropIndex(
                name: "IX_LayoutDetails_LayoutID",
                table: "LayoutDetails");

            migrationBuilder.CreateIndex(
                name: "IX_LayoutDetails_FullLayoutID",
                table: "LayoutDetails",
                column: "FullLayoutID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LayoutDetails_LayoutID",
                table: "LayoutDetails",
                column: "LayoutID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LayoutDetails_FullLayoutID",
                table: "LayoutDetails");

            migrationBuilder.DropIndex(
                name: "IX_LayoutDetails_LayoutID",
                table: "LayoutDetails");

            migrationBuilder.CreateIndex(
                name: "IX_LayoutDetails_FullLayoutID",
                table: "LayoutDetails",
                column: "FullLayoutID");

            migrationBuilder.CreateIndex(
                name: "IX_LayoutDetails_LayoutID",
                table: "LayoutDetails",
                column: "LayoutID");
        }
    }
}
