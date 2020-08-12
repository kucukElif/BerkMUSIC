using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BerkMusicUI.Migrations
{
    public partial class FullLyoutClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FullLayoutID",
                table: "Layouts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FullLayouts",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedComputerName = table.Column<string>(nullable: true),
                    CreatedIP = table.Column<string>(nullable: true),
                    CreatedAdUserName = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedComputerName = table.Column<string>(nullable: true),
                    ModifiedIP = table.Column<string>(nullable: true),
                    ModifiedAdUserName = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FullLayouts", x => x.ID);
                });

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

            migrationBuilder.DropTable(
                name: "FullLayouts");

            migrationBuilder.DropIndex(
                name: "IX_Layouts_FullLayoutID",
                table: "Layouts");

            migrationBuilder.DropColumn(
                name: "FullLayoutID",
                table: "Layouts");
        }
    }
}
