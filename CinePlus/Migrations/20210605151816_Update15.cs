using Microsoft.EntityFrameworkCore.Migrations;

namespace CinePlus.Migrations
{
    public partial class Update15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Payed",
                table: "PayCart");

            migrationBuilder.AddColumn<double>(
                name: "PayedMoney",
                table: "PayCart",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PayedPoints",
                table: "PayCart",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PayedMoney",
                table: "PayCart");

            migrationBuilder.DropColumn(
                name: "PayedPoints",
                table: "PayCart");

            migrationBuilder.AddColumn<double>(
                name: "Payed",
                table: "PayCart",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
