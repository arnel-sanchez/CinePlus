using Microsoft.EntityFrameworkCore.Migrations;

namespace CinePlus.Migrations
{
    public partial class Update12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Points",
                table: "Partner",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Points",
                table: "Partner",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
