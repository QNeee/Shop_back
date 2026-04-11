using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop_back.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddProduct1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Variants",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Variants",
                table: "Products");
        }
    }
}
