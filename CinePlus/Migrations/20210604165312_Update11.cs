using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CinePlus.Migrations
{
    public partial class Update11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pay_AspNetUsers_UserId",
                table: "Pay");

            migrationBuilder.DropIndex(
                name: "IX_Pay_UserId",
                table: "Pay");

            migrationBuilder.DropColumn(
                name: "CardHash",
                table: "Pay");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "Pay");

            migrationBuilder.DropColumn(
                name: "IdentifierDay",
                table: "Pay");

            migrationBuilder.DropColumn(
                name: "Payed",
                table: "Pay");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Pay");

            migrationBuilder.AddColumn<string>(
                name: "PayCartId",
                table: "Pay",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PayCart",
                columns: table => new
                {
                    PayCartId = table.Column<string>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Payed = table.Column<double>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    CardHash = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayCart", x => x.PayCartId);
                    table.ForeignKey(
                        name: "FK_PayCart_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pay_PayCartId",
                table: "Pay",
                column: "PayCartId");

            migrationBuilder.CreateIndex(
                name: "IX_PayCart_UserId",
                table: "PayCart",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pay_PayCart_PayCartId",
                table: "Pay",
                column: "PayCartId",
                principalTable: "PayCart",
                principalColumn: "PayCartId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pay_PayCart_PayCartId",
                table: "Pay");

            migrationBuilder.DropTable(
                name: "PayCart");

            migrationBuilder.DropIndex(
                name: "IX_Pay_PayCartId",
                table: "Pay");

            migrationBuilder.DropColumn(
                name: "PayCartId",
                table: "Pay");

            migrationBuilder.AddColumn<string>(
                name: "CardHash",
                table: "Pay",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "Pay",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "IdentifierDay",
                table: "Pay",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Payed",
                table: "Pay",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Pay",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pay_UserId",
                table: "Pay",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pay_AspNetUsers_UserId",
                table: "Pay",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
