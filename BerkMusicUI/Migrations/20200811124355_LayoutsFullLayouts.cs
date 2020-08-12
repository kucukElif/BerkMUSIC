using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BerkMusicUI.Migrations
{
    public partial class LayoutsFullLayouts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LayoutFullLayouts");

            migrationBuilder.AddColumn<Guid>(
                name: "LayoutID",
                table: "FullLayouts",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_FullLayouts_LayoutID",
                table: "FullLayouts",
                column: "LayoutID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FullLayouts_Layouts_LayoutID",
                table: "FullLayouts",
                column: "LayoutID",
                principalTable: "Layouts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "LayoutFullLayouts",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAdUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedComputerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullLayoutID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LayoutID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedAdUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedComputerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LayoutFullLayouts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LayoutFullLayouts_FullLayouts_FullLayoutID",
                        column: x => x.FullLayoutID,
                        principalTable: "FullLayouts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LayoutFullLayouts_Layouts_LayoutID",
                        column: x => x.LayoutID,
                        principalTable: "Layouts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LayoutFullLayouts_FullLayoutID",
                table: "LayoutFullLayouts",
                column: "FullLayoutID");

            migrationBuilder.CreateIndex(
                name: "IX_LayoutFullLayouts_LayoutID",
                table: "LayoutFullLayouts",
                column: "LayoutID");
        }
    }
}
