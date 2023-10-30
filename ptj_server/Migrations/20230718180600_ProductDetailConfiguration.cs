using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ptj_server.Migrations
{
    /// <inheritdoc />
    public partial class ProductDetailConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PRODUCT_DETAILS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRODUCT_ID = table.Column<int>(type: "int", nullable: true),
                    QUANTITY = table.Column<int>(type: "int", nullable: true),
                    IMPORT_QUANTITY = table.Column<int>(type: "int", nullable: true),
                    PRODUCT_PRICE_ID = table.Column<int>(type: "int", nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "date", nullable: true),
                    SIZE = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT_DETAIL", x => x.Id);
                    table.ForeignKey(
                        name: "FK__PRODUCT_D__PRODU__625A9A57",
                        column: x => x.PRODUCT_ID,
                        principalTable: "PRODUCTS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__PRODUCT_D__PRODU__634EBE90",
                        column: x => x.PRODUCT_PRICE_ID,
                        principalTable: "PRODUCT_PRICES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_DETAILS_PRODUCT_ID",
                table: "PRODUCT_DETAILS",
                column: "PRODUCT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_DETAILS_PRODUCT_PRICE_ID",
                table: "PRODUCT_DETAILS",
                column: "PRODUCT_PRICE_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRODUCT_DETAILS");
        }
    }
}
