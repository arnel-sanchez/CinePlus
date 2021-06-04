using Microsoft.EntityFrameworkCore.Migrations;

namespace CinePlus.Migrations
{
    public partial class Update13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "PriceInPoints",
                table: "Show",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "PriceInPoints",
                table: "Show",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
