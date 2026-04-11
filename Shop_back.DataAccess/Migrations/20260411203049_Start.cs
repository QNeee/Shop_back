using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop_back.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Start : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SmartVariants");

            migrationBuilder.DropTable(
                name: "Smarts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Smarts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Images = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Smarts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SmartVariants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SmartId = table.Column<Guid>(type: "uuid", nullable: false),
                    Discount = table.Column<string>(type: "text", nullable: false),
                    Memory = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    Stock = table.Column<int>(type: "integer", nullable: false),
                    Storage = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmartVariants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SmartVariants_Smarts_SmartId",
                        column: x => x.SmartId,
                        principalTable: "Smarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SmartVariants_SmartId",
                table: "SmartVariants",
                column: "SmartId");
        }
    }
}
