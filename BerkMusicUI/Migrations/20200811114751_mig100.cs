using Microsoft.EntityFrameworkCore.Migrations;

namespace BerkMusicUI.Migrations
{
    public partial class mig100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FullLayouts_Layouts_LayoutId",
                table: "FullLayouts");

            migrationBuilder.RenameColumn(
                name: "LayoutId",
                table: "FullLayouts",
                newName: "LayoutID");

            migrationBuilder.RenameIndex(
                name: "IX_FullLayouts_LayoutId",
                table: "FullLayouts",
                newName: "IX_FullLayouts_LayoutID");

            migrationBuilder.AddForeignKey(
                name: "FK_FullLayouts_Layouts_LayoutID",
                table: "FullLayouts",
                column: "LayoutID",
                principalTable: "Layouts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FullLayouts_Layouts_LayoutID",
                table: "FullLayouts");

            migrationBuilder.RenameColumn(
                name: "LayoutID",
                table: "FullLayouts",
                newName: "LayoutId");

            migrationBuilder.RenameIndex(
                name: "IX_FullLayouts_LayoutID",
                table: "FullLayouts",
                newName: "IX_FullLayouts_LayoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_FullLayouts_Layouts_LayoutId",
                table: "FullLayouts",
                column: "LayoutId",
                principalTable: "Layouts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
