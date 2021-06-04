using Microsoft.EntityFrameworkCore.Migrations;

namespace CinePlus.Migrations
{
    public partial class Update8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Identifier",
                table: "Pay");

            migrationBuilder.DropColumn(
                name: "Payed",
                table: "Pay");

            migrationBuilder.AddColumn<long>(
                name: "PriceInPoints",
                table: "Show",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "IdentifierDay",
                table: "Pay",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceInPoints",
                table: "Show");

            migrationBuilder.DropColumn(
                name: "IdentifierDay",
                table: "Pay");

            migrationBuilder.AddColumn<string>(
                name: "Identifier",
                table: "Pay",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Payed",
                table: "Pay",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
