using Microsoft.EntityFrameworkCore.Migrations;

namespace CinePlus.Migrations
{
    public partial class Update6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DiscountId",
                table: "Carts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Pay",
                columns: table => new
                {
                    PayId = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    CardHash = table.Column<string>(nullable: true),
                    Payed = table.Column<float>(nullable: false),
                    UserBoughtArmChairId = table.Column<string>(nullable: true),
                    UserBougthArmChairId = table.Column<string>(nullable: true),
                    DiscountId = table.Column<string>(nullable: true),
                    DiscountById = table.Column<string>(nullable: true),
                    Identifier = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pay", x => x.PayId);
                    table.ForeignKey(
                        name: "FK_Pay_Discount_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discount",
                        principalColumn: "DiscountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pay_UserBoughtArmChair_UserBoughtArmChairId",
                        column: x => x.UserBoughtArmChairId,
                        principalTable: "UserBoughtArmChair",
                        principalColumn: "UserBoughtArmChairId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pay_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_DiscountId",
                table: "Carts",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_Pay_DiscountId",
                table: "Pay",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_Pay_UserBoughtArmChairId",
                table: "Pay",
                column: "UserBoughtArmChairId");

            migrationBuilder.CreateIndex(
                name: "IX_Pay_UserId",
                table: "Pay",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Discount_DiscountId",
                table: "Carts",
                column: "DiscountId",
                principalTable: "Discount",
                principalColumn: "DiscountId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Discount_DiscountId",
                table: "Carts");

            migrationBuilder.DropTable(
                name: "Pay");

            migrationBuilder.DropIndex(
                name: "IX_Carts_DiscountId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "DiscountId",
                table: "Carts");
        }
    }
}
