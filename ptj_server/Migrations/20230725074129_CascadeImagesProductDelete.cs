using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ptj_server.Migrations
{
    /// <inheritdoc />
    public partial class CascadeImagesProductDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IMAGES_PRODUCTS",
                table: "IMAGES");

            migrationBuilder.AddForeignKey(
                name: "FK_IMAGES_PRODUCTS",
                table: "IMAGES",
                column: "PRODUCT_ID",
                principalTable: "PRODUCTS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IMAGES_PRODUCTS",
                table: "IMAGES");

            migrationBuilder.AddForeignKey(
                name: "FK_IMAGES_PRODUCTS",
                table: "IMAGES",
                column: "PRODUCT_ID",
                principalTable: "PRODUCTS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
