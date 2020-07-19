using Microsoft.EntityFrameworkCore.Migrations;

namespace _dock200.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "totalIpsSeen",
                table: "shinIps2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "totalIpsSeen",
                table: "shinIps2",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
