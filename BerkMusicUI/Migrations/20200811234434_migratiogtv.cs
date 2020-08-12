

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BerkMusicUI.Migrations
{
    public partial class migratiogtv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LayoutDetails_Layouts_LayoutID",
                table: "LayoutDetails");

            migrationBuilder.AlterColumn<Guid>(
                name: "LayoutID",
                table: "LayoutDetails",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_LayoutDetails_Layouts_LayoutID",
                table: "LayoutDetails",
                column: "LayoutID",
                principalTable: "Layouts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LayoutDetails_Layouts_LayoutID",
                table: "LayoutDetails");

            migrationBuilder.AlterColumn<Guid>(
                name: "LayoutID",
                table: "LayoutDetails",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LayoutDetails_Layouts_LayoutID",
                table: "LayoutDetails",
                column: "LayoutID",
                principalTable: "Layouts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
