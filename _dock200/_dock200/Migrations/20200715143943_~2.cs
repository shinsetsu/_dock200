using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _dock200.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegionCode",
                table: "shinIps2");

            migrationBuilder.DropColumn(
                name: "RegionName",
                table: "shinIps2");

            migrationBuilder.DropColumn(
                name: "TimesSeen",
                table: "shinIps2");

            migrationBuilder.AddColumn<DateTime>(
                name: "SeenDate",
                table: "shinIps2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "shinIps2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StateABR",
                table: "shinIps2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TimesSeenDated",
                table: "shinIps2",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeenDate",
                table: "shinIps2");

            migrationBuilder.DropColumn(
                name: "State",
                table: "shinIps2");

            migrationBuilder.DropColumn(
                name: "StateABR",
                table: "shinIps2");

            migrationBuilder.DropColumn(
                name: "TimesSeenDated",
                table: "shinIps2");

            migrationBuilder.AddColumn<string>(
                name: "RegionCode",
                table: "shinIps2",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegionName",
                table: "shinIps2",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TimesSeen",
                table: "shinIps2",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
