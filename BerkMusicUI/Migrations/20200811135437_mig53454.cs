using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BerkMusicUI.Migrations
{
    public partial class mig53454 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FullLayouts_Layouts_LayoutID",
                table: "FullLayouts");

            migrationBuilder.DropIndex(
                name: "IX_FullLayouts_LayoutID",
                table: "FullLayouts");

            migrationBuilder.DropColumn(
                name: "LayoutID",
                table: "FullLayouts");

            migrationBuilder.CreateIndex(
                name: "IX_Layouts_FullLayoutID",
                table: "Layouts",
                column: "FullLayoutID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Layouts_FullLayouts_FullLayoutID",
                table: "Layouts",
                column: "FullLayoutID",
                principalTable: "FullLayouts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Layouts_FullLayouts_FullLayoutID",
                table: "Layouts");

            migrationBuilder.DropIndex(
                name: "IX_Layouts_FullLayoutID",
                table: "Layouts");

            migrationBuilder.AddColumn<Guid>(
                name: "LayoutID",
                table: "FullLayouts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FullLayouts_LayoutID",
                table: "FullLayouts",
                column: "LayoutID");

            migrationBuilder.AddForeignKey(
                name: "FK_FullLayouts_Layouts_LayoutID",
                table: "FullLayouts",
                column: "LayoutID",
                principalTable: "Layouts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
