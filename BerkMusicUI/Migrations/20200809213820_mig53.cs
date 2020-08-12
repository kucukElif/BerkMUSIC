using Microsoft.EntityFrameworkCore.Migrations;

namespace BerkMusicUI.Migrations
{
    public partial class mig53 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FullLayouts_LayoutId",
                table: "FullLayouts");

            migrationBuilder.CreateIndex(
                name: "IX_FullLayouts_LayoutId",
                table: "FullLayouts",
                column: "LayoutId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FullLayouts_LayoutId",
                table: "FullLayouts");

            migrationBuilder.CreateIndex(
                name: "IX_FullLayouts_LayoutId",
                table: "FullLayouts",
                column: "LayoutId",
                unique: true);
        }
    }
}
