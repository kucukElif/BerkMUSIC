using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BerkMusicUI.Migrations
{
    public partial class mig97 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FullLayouts_Layouts_LayoutId",
                table: "FullLayouts");

            migrationBuilder.DropIndex(
                name: "IX_FullLayouts_LayoutId",
                table: "FullLayouts");

            migrationBuilder.AlterColumn<Guid>(
                name: "LayoutId",
                table: "FullLayouts",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FullLayouts_LayoutId",
                table: "FullLayouts",
                column: "LayoutId");

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

            migrationBuilder.DropIndex(
                name: "IX_FullLayouts_LayoutId",
                table: "FullLayouts");

            migrationBuilder.AlterColumn<Guid>(
                name: "LayoutId",
                table: "FullLayouts",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.CreateIndex(
                name: "IX_FullLayouts_LayoutId",
                table: "FullLayouts",
                column: "LayoutId",
                unique: true,
                filter: "[LayoutId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_FullLayouts_Layouts_LayoutId",
                table: "FullLayouts",
                column: "LayoutId",
                principalTable: "Layouts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
