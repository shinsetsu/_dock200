using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _dock200.Migrations
{
    public partial class _ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RefEmpAp_M",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TodayDate = table.Column<DateTime>(nullable: false),
                    FN = table.Column<string>(nullable: true),
                    LN = table.Column<string>(nullable: true),
                    MI = table.Column<string>(nullable: true),
                    StAddress = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Zipcode = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PermAddress = table.Column<string>(nullable: true),
                    PositionAppliedFor = table.Column<string>(nullable: true),
                    WorkWeekends = table.Column<string>(nullable: true),
                    WorkEvenings = table.Column<string>(nullable: true),
                    LegallyEligibleEmp = table.Column<string>(nullable: true),
                    Transportation = table.Column<string>(nullable: true),
                    HighestLevelAtended = table.Column<string>(nullable: true),
                    HighestDegree = table.Column<string>(nullable: true),
                    School = table.Column<string>(nullable: true),
                    CurrentlyStudent = table.Column<string>(nullable: true),
                    StudentCapacity = table.Column<string>(nullable: true),
                    Employer = table.Column<string>(nullable: true),
                    EMPDateFrom = table.Column<DateTime>(nullable: false),
                    EMPDateTo = table.Column<DateTime>(nullable: false),
                    EMPCity = table.Column<string>(nullable: true),
                    EMPState = table.Column<string>(nullable: true),
                    EMPPhone = table.Column<string>(nullable: true),
                    EMPManager = table.Column<string>(nullable: true),
                    MayWeContact = table.Column<string>(nullable: true),
                    Signature = table.Column<string>(nullable: true),
                    SigDate = table.Column<DateTime>(nullable: false),
                    DateRecieved = table.Column<DateTime>(nullable: false),
                    InterviewDate = table.Column<DateTime>(nullable: false),
                    SpecialNotes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefEmpAp_M", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "shinIps2",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IP = table.Column<string>(nullable: true),
                    type = table.Column<string>(nullable: true),
                    seenDate = table.Column<DateTime>(nullable: false),
                    timesSeenDay = table.Column<int>(nullable: false),
                    timesSeenCount = table.Column<long>(nullable: false),
                    totalIpsSeen = table.Column<long>(nullable: false),
                    countCode = table.Column<string>(nullable: true),
                    countName = table.Column<string>(nullable: true),
                    stateABR = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    zip = table.Column<string>(nullable: true),
                    latitude = table.Column<string>(nullable: true),
                    longitude = table.Column<string>(nullable: true)
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
                name: "RefEmpAp_M");

            migrationBuilder.DropTable(
                name: "shinIps2");

            migrationBuilder.DropTable(
                name: "shinSiteMetrics");

            migrationBuilder.DropTable(
                name: "shinUserSessionSettings");
        }
    }
}
