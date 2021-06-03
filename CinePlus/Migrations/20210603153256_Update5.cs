using Microsoft.EntityFrameworkCore.Migrations;

namespace CinePlus.Migrations
{
    public partial class Update5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Room",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ArmChairId",
                table: "Carts",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "No",
                table: "ArmChair",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ArmChairId",
                table: "Carts",
                column: "ArmChairId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_ArmChair_ArmChairId",
                table: "Carts",
                column: "ArmChairId",
                principalTable: "ArmChair",
                principalColumn: "ArmChairId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_ArmChair_ArmChairId",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_ArmChairId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "No",
                table: "ArmChair");

            migrationBuilder.AlterColumn<string>(
                name: "ArmChairId",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
