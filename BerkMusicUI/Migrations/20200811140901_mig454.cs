using Microsoft.EntityFrameworkCore.Migrations;

namespace BerkMusicUI.Migrations
{
    public partial class mig454 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LayoutFullLayouts_FullLayoutID",
                table: "LayoutFullLayouts");

            migrationBuilder.DropIndex(
                name: "IX_LayoutFullLayouts_LayoutID",
                table: "LayoutFullLayouts");

            migrationBuilder.CreateIndex(
                name: "IX_LayoutFullLayouts_FullLayoutID",
                table: "LayoutFullLayouts",
                column: "FullLayoutID");

            migrationBuilder.CreateIndex(
                name: "IX_LayoutFullLayouts_LayoutID",
                table: "LayoutFullLayouts",
                column: "LayoutID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LayoutFullLayouts_FullLayoutID",
                table: "LayoutFullLayouts");

            migrationBuilder.DropIndex(
                name: "IX_LayoutFullLayouts_LayoutID",
                table: "LayoutFullLayouts");

            migrationBuilder.CreateIndex(
                name: "IX_LayoutFullLayouts_FullLayoutID",
                table: "LayoutFullLayouts",
                column: "FullLayoutID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LayoutFullLayouts_LayoutID",
                table: "LayoutFullLayouts",
                column: "LayoutID",
                unique: true);
        }
    }
}
