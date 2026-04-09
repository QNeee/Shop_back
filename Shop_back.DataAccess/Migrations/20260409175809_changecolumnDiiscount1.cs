using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop_back.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class changecolumnDiiscount1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount_ExpiresAt",
                table: "SmartVariants");

            migrationBuilder.DropColumn(
                name: "Discount_Percent",
                table: "SmartVariants");

            migrationBuilder.AddColumn<string>(
                name: "Discount",
                table: "SmartVariants",
                type: "jsonb",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "SmartVariants");

            migrationBuilder.AddColumn<DateTime>(
                name: "Discount_ExpiresAt",
                table: "SmartVariants",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Discount_Percent",
                table: "SmartVariants",
                type: "integer",
                nullable: true);
        }
    }
}
