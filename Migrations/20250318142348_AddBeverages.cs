using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeverageAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddBeverages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beverages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BeverageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaffeineConent = table.Column<int>(type: "int", nullable: false),
                    DateDrank = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beverages");
        }
    }
}
