using Microsoft.EntityFrameworkCore.Migrations;

namespace BerkMusicUI.Migrations
{
    public partial class mig4354 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LayoutFullLayout_FullLayouts_FullLayoutID",
                table: "LayoutFullLayout");

            migrationBuilder.DropForeignKey(
                name: "FK_LayoutFullLayout_Layouts_LayoutID",
                table: "LayoutFullLayout");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LayoutFullLayout",
                table: "LayoutFullLayout");

            migrationBuilder.RenameTable(
                name: "LayoutFullLayout",
                newName: "LayoutFullLayouts");

            migrationBuilder.RenameIndex(
                name: "IX_LayoutFullLayout_LayoutID",
                table: "LayoutFullLayouts",
                newName: "IX_LayoutFullLayouts_LayoutID");

            migrationBuilder.RenameIndex(
                name: "IX_LayoutFullLayout_FullLayoutID",
                table: "LayoutFullLayouts",
                newName: "IX_LayoutFullLayouts_FullLayoutID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LayoutFullLayouts",
                table: "LayoutFullLayouts",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_LayoutFullLayouts_FullLayouts_FullLayoutID",
                table: "LayoutFullLayouts",
                column: "FullLayoutID",
                principalTable: "FullLayouts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LayoutFullLayouts_Layouts_LayoutID",
                table: "LayoutFullLayouts",
                column: "LayoutID",
                principalTable: "Layouts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LayoutFullLayouts_FullLayouts_FullLayoutID",
                table: "LayoutFullLayouts");

            migrationBuilder.DropForeignKey(
                name: "FK_LayoutFullLayouts_Layouts_LayoutID",
                table: "LayoutFullLayouts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LayoutFullLayouts",
                table: "LayoutFullLayouts");

            migrationBuilder.RenameTable(
                name: "LayoutFullLayouts",
                newName: "LayoutFullLayout");

            migrationBuilder.RenameIndex(
                name: "IX_LayoutFullLayouts_LayoutID",
                table: "LayoutFullLayout",
                newName: "IX_LayoutFullLayout_LayoutID");

            migrationBuilder.RenameIndex(
                name: "IX_LayoutFullLayouts_FullLayoutID",
                table: "LayoutFullLayout",
                newName: "IX_LayoutFullLayout_FullLayoutID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LayoutFullLayout",
                table: "LayoutFullLayout",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_LayoutFullLayout_FullLayouts_FullLayoutID",
                table: "LayoutFullLayout",
                column: "FullLayoutID",
                principalTable: "FullLayouts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LayoutFullLayout_Layouts_LayoutID",
                table: "LayoutFullLayout",
                column: "LayoutID",
                principalTable: "Layouts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
