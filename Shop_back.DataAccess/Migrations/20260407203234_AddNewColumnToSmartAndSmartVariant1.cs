using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop_back.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddNewColumnToSmartAndSmartVariant1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "SmartVariants");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "SmartVariants");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Smarts",
                newName: "Images");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Images",
                table: "Smarts",
                newName: "ImageUrl");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "SmartVariants",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "SmartVariants",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
