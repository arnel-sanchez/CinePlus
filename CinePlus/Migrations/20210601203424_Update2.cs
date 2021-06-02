using Microsoft.EntityFrameworkCore.Migrations;

namespace CinePlus.Migrations
{
    public partial class Update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Show_UserBoughtArmChair_UserBoughtArmChairId",
                table: "Show");

            migrationBuilder.DropIndex(
                name: "IX_Show_UserBoughtArmChairId",
                table: "Show");

            migrationBuilder.DropColumn(
                name: "UserBoughtArmChairId",
                table: "Show");

            migrationBuilder.AddColumn<string>(
                name: "ShowId",
                table: "UserBoughtArmChair",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserBoughtArmChair_ShowId",
                table: "UserBoughtArmChair",
                column: "ShowId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBoughtArmChair_Show_ShowId",
                table: "UserBoughtArmChair",
                column: "ShowId",
                principalTable: "Show",
                principalColumn: "ShowId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBoughtArmChair_Show_ShowId",
                table: "UserBoughtArmChair");

            migrationBuilder.DropIndex(
                name: "IX_UserBoughtArmChair_ShowId",
                table: "UserBoughtArmChair");

            migrationBuilder.DropColumn(
                name: "ShowId",
                table: "UserBoughtArmChair");

            migrationBuilder.AddColumn<string>(
                name: "UserBoughtArmChairId",
                table: "Show",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Show_UserBoughtArmChairId",
                table: "Show",
                column: "UserBoughtArmChairId");

            migrationBuilder.AddForeignKey(
                name: "FK_Show_UserBoughtArmChair_UserBoughtArmChairId",
                table: "Show",
                column: "UserBoughtArmChairId",
                principalTable: "UserBoughtArmChair",
                principalColumn: "UserBoughtArmChairId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
