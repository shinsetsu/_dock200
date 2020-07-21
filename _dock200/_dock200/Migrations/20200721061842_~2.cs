using Microsoft.EntityFrameworkCore.Migrations;

namespace _dock200.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "type",
                table: "shinIps2");

            migrationBuilder.AddColumn<int>(
                name: "IpType",
                table: "shinIps2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IpType",
                table: "shinIps2");

            migrationBuilder.AddColumn<string>(
                name: "type",
                table: "shinIps2",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
