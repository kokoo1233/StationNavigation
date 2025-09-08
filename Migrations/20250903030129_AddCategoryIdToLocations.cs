using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StationNavigation.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryIdToLocations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Locations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Locations");
        }
    }
}
