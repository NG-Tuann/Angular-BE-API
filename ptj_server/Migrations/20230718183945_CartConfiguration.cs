using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ptj_server.Migrations
{
    /// <inheritdoc />
    public partial class CartConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CARTS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CUSTOMER_ID = table.Column<int>(type: "int", nullable: true),
                    QUANTITY = table.Column<int>(type: "int", nullable: true),
                    ORDER_ID = table.Column<int>(type: "int", nullable: true),
                    PRODUCT_DETAIL_ID = table.Column<int>(type: "int", nullable: true),
                    IS_CHECK = table.Column<bool>(type: "bit", nullable: true),
                    SAVEPRICE = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CART", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CARTS_CUSTOMERS",
                        column: x => x.CUSTOMER_ID,
                        principalTable: "CUSTOMERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CARTS_ORDER_PRODUCTS",
                        column: x => x.ORDER_ID,
                        principalTable: "ORDER_PRODUCTS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__CARTS__PRODUCT_D__0697FACD",
                        column: x => x.PRODUCT_DETAIL_ID,
                        principalTable: "PRODUCT_DETAILS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CARTS_CUSTOMER_ID",
                table: "CARTS",
                column: "CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CARTS_ORDER_ID",
                table: "CARTS",
                column: "ORDER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CARTS_PRODUCT_DETAIL_ID",
                table: "CARTS",
                column: "PRODUCT_DETAIL_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CARTS");
        }
    }
}
