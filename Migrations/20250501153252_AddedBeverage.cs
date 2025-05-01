using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeverageAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedBeverage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BeverageName",
                table: "BeveragesLog");

            migrationBuilder.DropColumn(
                name: "CaffeineConent",
                table: "BeveragesLog");

            migrationBuilder.RenameColumn(
                name: "FluidOz",
                table: "BeveragesLog",
                newName: "BeverageId");

            migrationBuilder.CreateTable(
                name: "Beverages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BeverageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FluidOz = table.Column<float>(type: "real", nullable: false),
                    CaffeineConent = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beverages", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BeveragesLog_BeverageId",
                table: "BeveragesLog",
                column: "BeverageId");

            migrationBuilder.AddForeignKey(
                name: "FK_BeveragesLog_Beverages_BeverageId",
                table: "BeveragesLog",
                column: "BeverageId",
                principalTable: "Beverages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BeveragesLog_Beverages_BeverageId",
                table: "BeveragesLog");

            migrationBuilder.DropTable(
                name: "Beverages");

            migrationBuilder.DropIndex(
                name: "IX_BeveragesLog_BeverageId",
                table: "BeveragesLog");

            migrationBuilder.RenameColumn(
                name: "BeverageId",
                table: "BeveragesLog",
                newName: "FluidOz");

            migrationBuilder.AddColumn<string>(
                name: "BeverageName",
                table: "BeveragesLog",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CaffeineConent",
                table: "BeveragesLog",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
