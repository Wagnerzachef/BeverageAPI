using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeverageAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddBeveragesFluidOz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FluidOz",
                table: "Beverages",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FluidOz",
                table: "Beverages");
        }
    }
}
