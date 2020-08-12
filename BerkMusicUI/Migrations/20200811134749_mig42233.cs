using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BerkMusicUI.Migrations
{
    public partial class mig42233 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FullLayouts_Layouts_LayoutID",
                table: "FullLayouts");

            migrationBuilder.AddColumn<Guid>(
                name: "FullLayoutID",
                table: "Layouts",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "LayoutID",
                table: "FullLayouts",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_FullLayouts_Layouts_LayoutID",
                table: "FullLayouts",
                column: "LayoutID",
                principalTable: "Layouts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FullLayouts_Layouts_LayoutID",
                table: "FullLayouts");

            migrationBuilder.DropColumn(
                name: "FullLayoutID",
                table: "Layouts");

            migrationBuilder.AlterColumn<Guid>(
                name: "LayoutID",
                table: "FullLayouts",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FullLayouts_Layouts_LayoutID",
                table: "FullLayouts",
                column: "LayoutID",
                principalTable: "Layouts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
