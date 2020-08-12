using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BerkMusicUI.Migrations
{
    public partial class mig19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FullLayouts_Layouts_LayoutId",
                table: "FullLayouts");

            migrationBuilder.DropIndex(
                name: "IX_FullLayouts_LayoutId",
                table: "FullLayouts");

            migrationBuilder.DropColumn(
                name: "LayoutId",
                table: "FullLayouts");

            migrationBuilder.AddColumn<Guid>(
                name: "FullLayoutID",
                table: "Layouts",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FullLayouId",
                table: "FullLayouts",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Layouts_FullLayoutID",
                table: "Layouts",
                column: "FullLayoutID");

            migrationBuilder.AddForeignKey(
                name: "FK_Layouts_FullLayouts_FullLayoutID",
                table: "Layouts",
                column: "FullLayoutID",
                principalTable: "FullLayouts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Layouts_FullLayouts_FullLayoutID",
                table: "Layouts");

            migrationBuilder.DropIndex(
                name: "IX_Layouts_FullLayoutID",
                table: "Layouts");

            migrationBuilder.DropColumn(
                name: "FullLayoutID",
                table: "Layouts");

            migrationBuilder.DropColumn(
                name: "FullLayouId",
                table: "FullLayouts");

            migrationBuilder.AddColumn<Guid>(
                name: "LayoutId",
                table: "FullLayouts",
                type: "uniqueidentifier",
                nullable: true);

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
