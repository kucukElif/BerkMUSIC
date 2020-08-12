using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BerkMusicUI.Migrations
{
    public partial class öig45345 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "LayoutFullLayout",
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
                    table.PrimaryKey("PK_LayoutFullLayout", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LayoutFullLayout_FullLayouts_FullLayoutID",
                        column: x => x.FullLayoutID,
                        principalTable: "FullLayouts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LayoutFullLayout_Layouts_LayoutID",
                        column: x => x.LayoutID,
                        principalTable: "Layouts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LayoutFullLayout_FullLayoutID",
                table: "LayoutFullLayout",
                column: "FullLayoutID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LayoutFullLayout_LayoutID",
                table: "LayoutFullLayout",
                column: "LayoutID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LayoutFullLayout");

            migrationBuilder.AddColumn<Guid>(
                name: "FullLayoutID",
                table: "Layouts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
    }
}
