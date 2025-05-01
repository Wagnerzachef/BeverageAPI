using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeverageAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangeToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beverages");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Users");

            migrationBuilder.AddColumn<DateTime>(
                name: "dob",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "BeveragesLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BeverageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FluidOz = table.Column<int>(type: "int", nullable: false),
                    CaffeineConent = table.Column<int>(type: "int", nullable: false),
                    DateDrank = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeveragesLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BeveragesLog_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BeveragesLog_UserId",
                table: "BeveragesLog",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BeveragesLog");

            migrationBuilder.DropColumn(
                name: "dob",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Beverages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BeverageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaffeineConent = table.Column<int>(type: "int", nullable: false),
                    DateDrank = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FluidOz = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beverages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beverages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beverages_UserId",
                table: "Beverages",
                column: "UserId");
        }
    }
}
