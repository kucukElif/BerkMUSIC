using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BerkMusicUI.Migrations
{
    public partial class addHomeSettingsClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HomeSettings",
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
                    ImagePath = table.Column<string>(nullable: true),
                    CostImagePath = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Works = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeSettings", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HomeSettings");
        }
    }
}
