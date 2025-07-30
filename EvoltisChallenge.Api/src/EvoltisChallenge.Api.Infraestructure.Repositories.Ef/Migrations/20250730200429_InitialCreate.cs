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
                name: "product_categories",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_categories", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    price = table.Column<double>(type: "double", nullable: false),
                    product_category_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    modified_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.id);
                    table.ForeignKey(
                        name: "FK_products_product_categories_product_category_id",
                        column: x => x.product_category_id,
                        principalTable: "product_categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "product_categories",
                columns: new[] { "id", "description", "name" },
                values: new object[,]
                {
                    { new Guid("12345678-1234-1234-1234-1234567890ab"), "PC peripherals", "Peripherals" },
                    { new Guid("22345678-1234-1234-1234-1234567890ab"), "Wide clothes", "Clothes" },
                    { new Guid("32345678-1234-1234-1234-1234567890ab"), "PC hardware", "Hardware" }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "id", "created_at", "description", "modified_at", "name", "price", "product_category_id" },
                values: new object[,]
                {
                    { new Guid("42345678-1234-1234-1234-1234567890ab"), new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Logitech white", new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Keyboard", 33.5, new Guid("12345678-1234-1234-1234-1234567890ab") },
                    { new Guid("52345678-1234-1234-1234-1234567890ab"), new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Logitech black", new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mouse", 22.989999999999998, new Guid("12345678-1234-1234-1234-1234567890ab") },
                    { new Guid("62345678-1234-1234-1234-1234567890ab"), new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Green XXL", new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shirt", 15.99, new Guid("22345678-1234-1234-1234-1234567890ab") },
                    { new Guid("72345678-1234-1234-1234-1234567890ab"), new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "New School", new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cap", 10.99, new Guid("22345678-1234-1234-1234-1234567890ab") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_product_category_id",
                table: "products",
                column: "product_category_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "product_categories");
        }
    }
}
