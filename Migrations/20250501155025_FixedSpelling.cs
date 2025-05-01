using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeverageAPI.Migrations
{
    /// <inheritdoc />
    public partial class FixedSpelling : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CaffeineConent",
                table: "Beverages",
                newName: "CaffeineContent");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CaffeineContent",
                table: "Beverages",
                newName: "CaffeineConent");
        }
    }
}
