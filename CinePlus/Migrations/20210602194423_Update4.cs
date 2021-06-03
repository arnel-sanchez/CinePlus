using Microsoft.EntityFrameworkCore.Migrations;

namespace CinePlus.Migrations
{
    public partial class Update4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_UserBoughtArmChair_UserBoughtArmChairId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBoughtArmChair_ArmChair_ArmChairId",
                table: "UserBoughtArmChair");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBoughtArmChair_Room_RoomId",
                table: "UserBoughtArmChair");

            migrationBuilder.DropIndex(
                name: "IX_UserBoughtArmChair_ArmChairId",
                table: "UserBoughtArmChair");

            migrationBuilder.DropIndex(
                name: "IX_UserBoughtArmChair_RoomId",
                table: "UserBoughtArmChair");

            migrationBuilder.DropIndex(
                name: "IX_Carts_UserBoughtArmChairId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "ArmChairId",
                table: "UserBoughtArmChair");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "UserBoughtArmChair");

            migrationBuilder.DropColumn(
                name: "UserBoughtArmChairId",
                table: "Carts");

            migrationBuilder.AddColumn<string>(
                name: "ArmChairByRoomId",
                table: "UserBoughtArmChair",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArmChairId",
                table: "Carts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShowId",
                table: "Carts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ArmChairByRoom",
                columns: table => new
                {
                    ArmChairByRoomId = table.Column<string>(nullable: false),
                    ArmChairId = table.Column<string>(nullable: true),
                    RoomId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmChairByRoom", x => x.ArmChairByRoomId);
                    table.ForeignKey(
                        name: "FK_ArmChairByRoom_ArmChair_ArmChairId",
                        column: x => x.ArmChairId,
                        principalTable: "ArmChair",
                        principalColumn: "ArmChairId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArmChairByRoom_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserBoughtArmChair_ArmChairByRoomId",
                table: "UserBoughtArmChair",
                column: "ArmChairByRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ShowId",
                table: "Carts",
                column: "ShowId");

            migrationBuilder.CreateIndex(
                name: "IX_ArmChairByRoom_ArmChairId",
                table: "ArmChairByRoom",
                column: "ArmChairId");

            migrationBuilder.CreateIndex(
                name: "IX_ArmChairByRoom_RoomId",
                table: "ArmChairByRoom",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Show_ShowId",
                table: "Carts",
                column: "ShowId",
                principalTable: "Show",
                principalColumn: "ShowId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBoughtArmChair_ArmChairByRoom_ArmChairByRoomId",
                table: "UserBoughtArmChair",
                column: "ArmChairByRoomId",
                principalTable: "ArmChairByRoom",
                principalColumn: "ArmChairByRoomId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Show_ShowId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBoughtArmChair_ArmChairByRoom_ArmChairByRoomId",
                table: "UserBoughtArmChair");

            migrationBuilder.DropTable(
                name: "ArmChairByRoom");

            migrationBuilder.DropIndex(
                name: "IX_UserBoughtArmChair_ArmChairByRoomId",
                table: "UserBoughtArmChair");

            migrationBuilder.DropIndex(
                name: "IX_Carts_ShowId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "ArmChairByRoomId",
                table: "UserBoughtArmChair");

            migrationBuilder.DropColumn(
                name: "ArmChairId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "ShowId",
                table: "Carts");

            migrationBuilder.AddColumn<string>(
                name: "ArmChairId",
                table: "UserBoughtArmChair",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoomId",
                table: "UserBoughtArmChair",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserBoughtArmChairId",
                table: "Carts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserBoughtArmChair_ArmChairId",
                table: "UserBoughtArmChair",
                column: "ArmChairId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBoughtArmChair_RoomId",
                table: "UserBoughtArmChair",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserBoughtArmChairId",
                table: "Carts",
                column: "UserBoughtArmChairId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_UserBoughtArmChair_UserBoughtArmChairId",
                table: "Carts",
                column: "UserBoughtArmChairId",
                principalTable: "UserBoughtArmChair",
                principalColumn: "UserBoughtArmChairId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBoughtArmChair_ArmChair_ArmChairId",
                table: "UserBoughtArmChair",
                column: "ArmChairId",
                principalTable: "ArmChair",
                principalColumn: "ArmChairId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBoughtArmChair_Room_RoomId",
                table: "UserBoughtArmChair",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
