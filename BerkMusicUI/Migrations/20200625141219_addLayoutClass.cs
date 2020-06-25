using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BerkMusicUI.Migrations
{
    public partial class addLayoutClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HomeSettings");

            migrationBuilder.CreateTable(
                name: "Layouts",
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
                    table.PrimaryKey("PK_Layouts", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Layouts");

            migrationBuilder.CreateTable(
                name: "HomeSettings",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cost1ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost2ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost3ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAdUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedComputerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAdUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedComputerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nav1ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nav2ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nav3ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Works = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeSettings", x => x.ID);
                });
        }
    }
}
