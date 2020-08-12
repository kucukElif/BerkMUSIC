﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BerkMusicUI.Migrations
{
    public partial class migratiooonn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Layouts_FullLayouts_FullLayoutID",
                table: "Layouts");

            migrationBuilder.DropIndex(
                name: "IX_Layouts_FullLayoutID",
                table: "Layouts");

            migrationBuilder.RenameColumn(
                name: "FullLayoutID",
                table: "Layouts",
                newName: "FullLayoutId");

            migrationBuilder.AlterColumn<Guid>(
                name: "FullLayoutId",
                table: "Layouts",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LayoutId",
                table: "FullLayouts",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_FullLayouts_LayoutId",
                table: "FullLayouts",
                column: "LayoutId",
                unique: true);

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

            migrationBuilder.DropColumn(
                name: "LayoutId",
                table: "FullLayouts");

            migrationBuilder.RenameColumn(
                name: "FullLayoutId",
                table: "Layouts",
                newName: "FullLayoutID");

            migrationBuilder.AlterColumn<Guid>(
                name: "FullLayoutID",
                table: "Layouts",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

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
    }
}
