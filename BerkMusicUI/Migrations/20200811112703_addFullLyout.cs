using Microsoft.EntityFrameworkCore.Migrations;

namespace BerkMusicUI.Migrations
{
    public partial class addFullLyout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FullLayout_Layouts_LayoutId",
                table: "FullLayout");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FullLayout",
                table: "FullLayout");

            migrationBuilder.RenameTable(
                name: "FullLayout",
                newName: "FullLayouts");

            migrationBuilder.RenameIndex(
                name: "IX_FullLayout_LayoutId",
                table: "FullLayouts",
                newName: "IX_FullLayouts_LayoutId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FullLayouts",
                table: "FullLayouts",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_FullLayouts_Layouts_LayoutId",
                table: "FullLayouts",
                column: "LayoutId",
                principalTable: "Layouts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FullLayouts_Layouts_LayoutId",
                table: "FullLayouts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FullLayouts",
                table: "FullLayouts");

            migrationBuilder.RenameTable(
                name: "FullLayouts",
                newName: "FullLayout");

            migrationBuilder.RenameIndex(
                name: "IX_FullLayouts_LayoutId",
                table: "FullLayout",
                newName: "IX_FullLayout_LayoutId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FullLayout",
                table: "FullLayout",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_FullLayout_Layouts_LayoutId",
                table: "FullLayout",
                column: "LayoutId",
                principalTable: "Layouts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
