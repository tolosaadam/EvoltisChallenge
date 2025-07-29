using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EvoltisChallenge.Api.Infraestructure.Repositories.Ef.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<double>(type: "double", nullable: false),
                    ProductCategoryId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("12345678-1234-1234-1234-1234567890ab"), "PC peripherals", "Peripherals" },
                    { new Guid("22345678-1234-1234-1234-1234567890ab"), "Wide clothes", "Clothes" },
                    { new Guid("32345678-1234-1234-1234-1234567890ab"), "PC hardware", "Hardware" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "Description", "ModifiedAt", "Name", "Price", "ProductCategoryId" },
                values: new object[,]
                {
                    { new Guid("42345678-1234-1234-1234-1234567890ab"), new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Logitech white", new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Keyboard", 33.5, new Guid("12345678-1234-1234-1234-1234567890ab") },
                    { new Guid("52345678-1234-1234-1234-1234567890ab"), new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Logitech black", new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mouse", 22.989999999999998, new Guid("12345678-1234-1234-1234-1234567890ab") },
                    { new Guid("62345678-1234-1234-1234-1234567890ab"), new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Green XXL", new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shirt", 15.99, new Guid("22345678-1234-1234-1234-1234567890ab") },
                    { new Guid("72345678-1234-1234-1234-1234567890ab"), new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "New School", new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cap", 10.99, new Guid("22345678-1234-1234-1234-1234567890ab") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductCategories");
        }
    }
}
