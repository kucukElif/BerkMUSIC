using Microsoft.EntityFrameworkCore.Migrations;

namespace BerkMusicUI.Migrations
{
    public partial class mig103 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FullLayouts_LayoutID",
                table: "FullLayouts");

            migrationBuilder.CreateIndex(
                name: "IX_FullLayouts_LayoutID",
                table: "FullLayouts",
                column: "LayoutID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FullLayouts_LayoutID",
                table: "FullLayouts");

            migrationBuilder.CreateIndex(
                name: "IX_FullLayouts_LayoutID",
                table: "FullLayouts",
                column: "LayoutID",
                unique: true);
        }
    }
}
