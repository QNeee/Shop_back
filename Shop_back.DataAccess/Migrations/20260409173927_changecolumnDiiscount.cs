using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop_back.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class changecolumnDiiscount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Discount",
                table: "SmartVariants",
                newName: "Discount_Percent");

            migrationBuilder.AddColumn<DateTime>(
                name: "Discount_ExpiresAt",
                table: "SmartVariants",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount_ExpiresAt",
                table: "SmartVariants");

            migrationBuilder.RenameColumn(
                name: "Discount_Percent",
                table: "SmartVariants",
                newName: "Discount");
        }
    }
}
