using Microsoft.EntityFrameworkCore.Migrations;

namespace CinePlus.Migrations
{
    public partial class Update14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Show_ShowId",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_ShowId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "DiscountId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "ShowId",
                table: "Carts");

            migrationBuilder.AddColumn<string>(
                name: "DiscountsByShowId",
                table: "Carts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carts_DiscountsByShowId",
                table: "Carts",
                column: "DiscountsByShowId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_DiscountsByShow_DiscountsByShowId",
                table: "Carts",
                column: "DiscountsByShowId",
                principalTable: "DiscountsByShow",
                principalColumn: "DiscountsByShowId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_DiscountsByShow_DiscountsByShowId",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_DiscountsByShowId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "DiscountsByShowId",
                table: "Carts");

            migrationBuilder.AddColumn<string>(
                name: "DiscountId",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShowId",
                table: "Carts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ShowId",
                table: "Carts",
                column: "ShowId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Show_ShowId",
                table: "Carts",
                column: "ShowId",
                principalTable: "Show",
                principalColumn: "ShowId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
