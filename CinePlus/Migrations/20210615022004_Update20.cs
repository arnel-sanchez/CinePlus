using Microsoft.EntityFrameworkCore.Migrations;

namespace CinePlus.Migrations
{
    public partial class Update20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StateArmChair",
                table: "ArmChair");

            migrationBuilder.AddColumn<string>(
                name: "ShowId",
                table: "ArmChairByRoom",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StateArmChair",
                table: "ArmChairByRoom",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ArmChairByRoom_ShowId",
                table: "ArmChairByRoom",
                column: "ShowId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArmChairByRoom_Show_ShowId",
                table: "ArmChairByRoom",
                column: "ShowId",
                principalTable: "Show",
                principalColumn: "ShowId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArmChairByRoom_Show_ShowId",
                table: "ArmChairByRoom");

            migrationBuilder.DropIndex(
                name: "IX_ArmChairByRoom_ShowId",
                table: "ArmChairByRoom");

            migrationBuilder.DropColumn(
                name: "ShowId",
                table: "ArmChairByRoom");

            migrationBuilder.DropColumn(
                name: "StateArmChair",
                table: "ArmChairByRoom");

            migrationBuilder.AddColumn<int>(
                name: "StateArmChair",
                table: "ArmChair",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
