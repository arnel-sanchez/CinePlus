using Microsoft.EntityFrameworkCore.Migrations;

namespace CinePlus.Migrations
{
    public partial class Update7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Discount_DiscountId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Pay_Discount_DiscountId",
                table: "Pay");

            migrationBuilder.DropIndex(
                name: "IX_Pay_DiscountId",
                table: "Pay");

            migrationBuilder.DropIndex(
                name: "IX_Carts_DiscountId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "DiscountId",
                table: "Pay");

            migrationBuilder.AlterColumn<string>(
                name: "DiscountId",
                table: "Carts",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DiscountId",
                table: "Pay",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DiscountId",
                table: "Carts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pay_DiscountId",
                table: "Pay",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_DiscountId",
                table: "Carts",
                column: "DiscountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Discount_DiscountId",
                table: "Carts",
                column: "DiscountId",
                principalTable: "Discount",
                principalColumn: "DiscountId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pay_Discount_DiscountId",
                table: "Pay",
                column: "DiscountId",
                principalTable: "Discount",
                principalColumn: "DiscountId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
