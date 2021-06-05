using Microsoft.EntityFrameworkCore.Migrations;

namespace CinePlus.Migrations
{
    public partial class Update16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DiscountId",
                table: "Pay",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pay_DiscountId",
                table: "Pay",
                column: "DiscountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pay_Discount_DiscountId",
                table: "Pay",
                column: "DiscountId",
                principalTable: "Discount",
                principalColumn: "DiscountId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pay_Discount_DiscountId",
                table: "Pay");

            migrationBuilder.DropIndex(
                name: "IX_Pay_DiscountId",
                table: "Pay");

            migrationBuilder.DropColumn(
                name: "DiscountId",
                table: "Pay");
        }
    }
}
