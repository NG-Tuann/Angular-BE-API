using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ptj_server.Migrations
{
    /// <inheritdoc />
    public partial class PromotionDetailConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PROMOTION_DETAILS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PROMOTION_ID = table.Column<int>(type: "int", nullable: true),
                    CUSTOMER_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROMOTION_DETAIL", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PROMOTION_DETAIL_CUSTOMERS",
                        column: x => x.CUSTOMER_ID,
                        principalTable: "CUSTOMERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PROMOTION_DETAIL_PROMOTIONS",
                        column: x => x.PROMOTION_ID,
                        principalTable: "PROMOTIONS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PROMOTION_DETAILS_CUSTOMER_ID",
                table: "PROMOTION_DETAILS",
                column: "CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROMOTION_DETAILS_PROMOTION_ID",
                table: "PROMOTION_DETAILS",
                column: "PROMOTION_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PROMOTION_DETAILS");
        }
    }
}
