using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _dock200.Migrations
{
    public partial class _ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "shinIps2",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IP = table.Column<string>(nullable: true),
                    TimesSeen = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    CountCode = table.Column<string>(nullable: true),
                    CountName = table.Column<string>(nullable: true),
                    RegionCode = table.Column<string>(nullable: true),
                    RegionName = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true),
                    Latitude = table.Column<string>(nullable: true),
                    Longitude = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shinIps2", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "shinSiteMetrics",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pageViewsDebug = table.Column<int>(nullable: false),
                    pageViewsRelease = table.Column<int>(nullable: false),
                    pageViewsEx = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shinSiteMetrics", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "shinUserSessionSettings",
                columns: table => new
                {
                    io = table.Column<string>(nullable: false),
                    IP = table.Column<string>(nullable: true),
                    DarkStyle = table.Column<bool>(nullable: false),
                    expirationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shinUserSessionSettings", x => x.io);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "shinIps2");

            migrationBuilder.DropTable(
                name: "shinSiteMetrics");

            migrationBuilder.DropTable(
                name: "shinUserSessionSettings");
        }
    }
}
