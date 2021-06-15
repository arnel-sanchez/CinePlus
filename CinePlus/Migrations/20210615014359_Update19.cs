using Microsoft.EntityFrameworkCore.Migrations;

namespace CinePlus.Migrations
{
    public partial class Update19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArmChairByRoom_ArmChair_ArmChairId",
                table: "ArmChairByRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_ArmChairByRoom_Room_RoomId",
                table: "ArmChairByRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_ArmChair_ArmChairId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_DiscountsByShow_DiscountsByShowId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_AspNetUsers_UserId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_DiscountsByShow_Discount_DiscountId",
                table: "DiscountsByShow");

            migrationBuilder.DropForeignKey(
                name: "FK_DiscountsByShow_Show_ShowId",
                table: "DiscountsByShow");

            migrationBuilder.DropForeignKey(
                name: "FK_Movie_MovieType_MovieTypeId",
                table: "Movie");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieOnTop10_Movie_MovieId",
                table: "MovieOnTop10");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieOnTop10_Top10_Top10Id",
                table: "MovieOnTop10");

            migrationBuilder.DropForeignKey(
                name: "FK_Partner_AspNetUsers_UserId",
                table: "Partner");

            migrationBuilder.DropForeignKey(
                name: "FK_Pay_Discount_DiscountId",
                table: "Pay");

            migrationBuilder.DropForeignKey(
                name: "FK_Pay_PayCart_PayCartId",
                table: "Pay");

            migrationBuilder.DropForeignKey(
                name: "FK_PayCart_AspNetUsers_UserId",
                table: "PayCart");

            migrationBuilder.DropForeignKey(
                name: "FK_Show_Movie_MovieId",
                table: "Show");

            migrationBuilder.DropForeignKey(
                name: "FK_Show_Room_RoomId",
                table: "Show");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBoughtArmChair_ArmChairByRoom_ArmChairByRoomId",
                table: "UserBoughtArmChair");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBoughtArmChair_AspNetUsers_UserId",
                table: "UserBoughtArmChair");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserBoughtArmChair",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ArmChairByRoomId",
                table: "UserBoughtArmChair",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Top10",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RoomId",
                table: "Show",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MovieId",
                table: "Show",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Room",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "PayCart",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CardHash",
                table: "PayCart",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserBougthArmChairId",
                table: "Pay",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PayCartId",
                table: "Pay",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DiscountId",
                table: "Pay",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Partner",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Partner",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MovieType",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Top10Id",
                table: "MovieOnTop10",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MovieId",
                table: "MovieOnTop10",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "URL",
                table: "Movie",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Movie",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MovieTypeId",
                table: "Movie",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Director",
                table: "Movie",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Movie",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShowId",
                table: "DiscountsByShow",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DiscountId",
                table: "DiscountsByShow",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Discount",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Carts",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DiscountsByShowId",
                table: "Carts",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ArmChairId",
                table: "Carts",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RoomId",
                table: "ArmChairByRoom",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ArmChairId",
                table: "ArmChairByRoom",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "No",
                table: "ArmChair",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ArmChairByRoom_ArmChair_ArmChairId",
                table: "ArmChairByRoom",
                column: "ArmChairId",
                principalTable: "ArmChair",
                principalColumn: "ArmChairId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArmChairByRoom_Room_RoomId",
                table: "ArmChairByRoom",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_ArmChair_ArmChairId",
                table: "Carts",
                column: "ArmChairId",
                principalTable: "ArmChair",
                principalColumn: "ArmChairId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_DiscountsByShow_DiscountsByShowId",
                table: "Carts",
                column: "DiscountsByShowId",
                principalTable: "DiscountsByShow",
                principalColumn: "DiscountsByShowId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_AspNetUsers_UserId",
                table: "Carts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DiscountsByShow_Discount_DiscountId",
                table: "DiscountsByShow",
                column: "DiscountId",
                principalTable: "Discount",
                principalColumn: "DiscountId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DiscountsByShow_Show_ShowId",
                table: "DiscountsByShow",
                column: "ShowId",
                principalTable: "Show",
                principalColumn: "ShowId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_MovieType_MovieTypeId",
                table: "Movie",
                column: "MovieTypeId",
                principalTable: "MovieType",
                principalColumn: "MovieTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieOnTop10_Movie_MovieId",
                table: "MovieOnTop10",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieOnTop10_Top10_Top10Id",
                table: "MovieOnTop10",
                column: "Top10Id",
                principalTable: "Top10",
                principalColumn: "Top10Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Partner_AspNetUsers_UserId",
                table: "Partner",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pay_Discount_DiscountId",
                table: "Pay",
                column: "DiscountId",
                principalTable: "Discount",
                principalColumn: "DiscountId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pay_PayCart_PayCartId",
                table: "Pay",
                column: "PayCartId",
                principalTable: "PayCart",
                principalColumn: "PayCartId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PayCart_AspNetUsers_UserId",
                table: "PayCart",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Show_Movie_MovieId",
                table: "Show",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Show_Room_RoomId",
                table: "Show",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBoughtArmChair_ArmChairByRoom_ArmChairByRoomId",
                table: "UserBoughtArmChair",
                column: "ArmChairByRoomId",
                principalTable: "ArmChairByRoom",
                principalColumn: "ArmChairByRoomId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBoughtArmChair_AspNetUsers_UserId",
                table: "UserBoughtArmChair",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArmChairByRoom_ArmChair_ArmChairId",
                table: "ArmChairByRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_ArmChairByRoom_Room_RoomId",
                table: "ArmChairByRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_ArmChair_ArmChairId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_DiscountsByShow_DiscountsByShowId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_AspNetUsers_UserId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_DiscountsByShow_Discount_DiscountId",
                table: "DiscountsByShow");

            migrationBuilder.DropForeignKey(
                name: "FK_DiscountsByShow_Show_ShowId",
                table: "DiscountsByShow");

            migrationBuilder.DropForeignKey(
                name: "FK_Movie_MovieType_MovieTypeId",
                table: "Movie");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieOnTop10_Movie_MovieId",
                table: "MovieOnTop10");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieOnTop10_Top10_Top10Id",
                table: "MovieOnTop10");

            migrationBuilder.DropForeignKey(
                name: "FK_Partner_AspNetUsers_UserId",
                table: "Partner");

            migrationBuilder.DropForeignKey(
                name: "FK_Pay_Discount_DiscountId",
                table: "Pay");

            migrationBuilder.DropForeignKey(
                name: "FK_Pay_PayCart_PayCartId",
                table: "Pay");

            migrationBuilder.DropForeignKey(
                name: "FK_PayCart_AspNetUsers_UserId",
                table: "PayCart");

            migrationBuilder.DropForeignKey(
                name: "FK_Show_Movie_MovieId",
                table: "Show");

            migrationBuilder.DropForeignKey(
                name: "FK_Show_Room_RoomId",
                table: "Show");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBoughtArmChair_ArmChairByRoom_ArmChairByRoomId",
                table: "UserBoughtArmChair");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBoughtArmChair_AspNetUsers_UserId",
                table: "UserBoughtArmChair");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserBoughtArmChair",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ArmChairByRoomId",
                table: "UserBoughtArmChair",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Top10",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "RoomId",
                table: "Show",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "MovieId",
                table: "Show",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Room",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "PayCart",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "CardHash",
                table: "PayCart",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "UserBougthArmChairId",
                table: "Pay",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "PayCartId",
                table: "Pay",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "DiscountId",
                table: "Pay",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Partner",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Partner",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MovieType",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Top10Id",
                table: "MovieOnTop10",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "MovieId",
                table: "MovieOnTop10",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "URL",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "MovieTypeId",
                table: "Movie",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Director",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ShowId",
                table: "DiscountsByShow",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "DiscountId",
                table: "DiscountsByShow",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Discount",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Carts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "DiscountsByShowId",
                table: "Carts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ArmChairId",
                table: "Carts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "RoomId",
                table: "ArmChairByRoom",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ArmChairId",
                table: "ArmChairByRoom",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "No",
                table: "ArmChair",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ArmChairByRoom_ArmChair_ArmChairId",
                table: "ArmChairByRoom",
                column: "ArmChairId",
                principalTable: "ArmChair",
                principalColumn: "ArmChairId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArmChairByRoom_Room_RoomId",
                table: "ArmChairByRoom",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_ArmChair_ArmChairId",
                table: "Carts",
                column: "ArmChairId",
                principalTable: "ArmChair",
                principalColumn: "ArmChairId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_DiscountsByShow_DiscountsByShowId",
                table: "Carts",
                column: "DiscountsByShowId",
                principalTable: "DiscountsByShow",
                principalColumn: "DiscountsByShowId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_AspNetUsers_UserId",
                table: "Carts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DiscountsByShow_Discount_DiscountId",
                table: "DiscountsByShow",
                column: "DiscountId",
                principalTable: "Discount",
                principalColumn: "DiscountId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DiscountsByShow_Show_ShowId",
                table: "DiscountsByShow",
                column: "ShowId",
                principalTable: "Show",
                principalColumn: "ShowId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_MovieType_MovieTypeId",
                table: "Movie",
                column: "MovieTypeId",
                principalTable: "MovieType",
                principalColumn: "MovieTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieOnTop10_Movie_MovieId",
                table: "MovieOnTop10",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieOnTop10_Top10_Top10Id",
                table: "MovieOnTop10",
                column: "Top10Id",
                principalTable: "Top10",
                principalColumn: "Top10Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Partner_AspNetUsers_UserId",
                table: "Partner",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pay_Discount_DiscountId",
                table: "Pay",
                column: "DiscountId",
                principalTable: "Discount",
                principalColumn: "DiscountId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pay_PayCart_PayCartId",
                table: "Pay",
                column: "PayCartId",
                principalTable: "PayCart",
                principalColumn: "PayCartId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PayCart_AspNetUsers_UserId",
                table: "PayCart",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Show_Movie_MovieId",
                table: "Show",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Show_Room_RoomId",
                table: "Show",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBoughtArmChair_ArmChairByRoom_ArmChairByRoomId",
                table: "UserBoughtArmChair",
                column: "ArmChairByRoomId",
                principalTable: "ArmChairByRoom",
                principalColumn: "ArmChairByRoomId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBoughtArmChair_AspNetUsers_UserId",
                table: "UserBoughtArmChair",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
