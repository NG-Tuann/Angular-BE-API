using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ptj_server.Migrations
{
    /// <inheritdoc />
    public partial class ProductDiscountConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PRODUCT_DISCOUNTS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DISCOUNT_VALUE = table.Column<int>(type: "int", nullable: false),
                    DISCOUNT_UNIT = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false),
                    DATE_CREATED = table.Column<DateTime>(type: "date", nullable: true),
                    VALID_UNTIL = table.Column<DateTime>(type: "date", nullable: true),
                    ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PRODUCT_ID = table.Column<int>(type: "int", nullable: true),
                    STONE_ID = table.Column<int>(type: "int", nullable: true),
                    GEM_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT_DISCOUNT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PRODUCT_DISCOUNTS_PRODUCTS",
                        column: x => x.PRODUCT_ID,
                        principalTable: "PRODUCTS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_pdc_gem",
                        column: x => x.GEM_ID,
                        principalTable: "GEOMANCIES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_pdc_stone",
                        column: x => x.STONE_ID,
                        principalTable: "STONE_TYPES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_DISCOUNTS_GEM_ID",
                table: "PRODUCT_DISCOUNTS",
                column: "GEM_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_DISCOUNTS_PRODUCT_ID",
                table: "PRODUCT_DISCOUNTS",
                column: "PRODUCT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_DISCOUNTS_STONE_ID",
                table: "PRODUCT_DISCOUNTS",
                column: "STONE_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRODUCT_DISCOUNTS");
        }
    }
}
