using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BerkMusicUI.Migrations
{
    public partial class mig3434 : Migration
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

            migrationBuilder.CreateTable(
                name: "LayoutDetails",
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
                    LayoutID = table.Column<Guid>(nullable: false),
                    FullLayoutID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LayoutDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LayoutDetails_FullLayouts_FullLayoutID",
                        column: x => x.FullLayoutID,
                        principalTable: "FullLayouts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LayoutDetails_Layouts_LayoutID",
                        column: x => x.LayoutID,
                        principalTable: "Layouts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LayoutDetails_FullLayoutID",
                table: "LayoutDetails",
                column: "FullLayoutID");

            migrationBuilder.CreateIndex(
                name: "IX_LayoutDetails_LayoutID",
                table: "LayoutDetails",
                column: "LayoutID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LayoutDetails");

            migrationBuilder.AddColumn<Guid>(
                name: "LayoutID",
                table: "FullLayouts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
