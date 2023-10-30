using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ptj_server.Migrations
{
    /// <inheritdoc />
    public partial class ProductConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PRODUCTS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GEOMANCY_ID = table.Column<int>(type: "int", nullable: true),
                    IMAGE = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    COLOR = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    NOTE = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    BEST_SELLER = table.Column<bool>(type: "bit", nullable: false),
                    HOME_FLAG = table.Column<bool>(type: "bit", nullable: false),
                    ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    CAT_ID = table.Column<int>(type: "int", nullable: true),
                    MAIN_STONE_ID = table.Column<int>(type: "int", nullable: true),
                    SUB_STONE_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PRODUCTS_CATEGORY_PRODUCTS",
                        column: x => x.CAT_ID,
                        principalTable: "CATEGORY_PRODUCTS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRODUCTS_GEOMANCIES",
                        column: x => x.GEOMANCY_ID,
                        principalTable: "GEOMANCIES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__PRODUCTS__MAIN_S__3C34F16F",
                        column: x => x.MAIN_STONE_ID,
                        principalTable: "STONE_TYPES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__PRODUCTS__SUB_ST__3D2915A8",
                        column: x => x.SUB_STONE_ID,
                        principalTable: "STONE_TYPES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_CAT_ID",
                table: "PRODUCTS",
                column: "CAT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_GEOMANCY_ID",
                table: "PRODUCTS",
                column: "GEOMANCY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_MAIN_STONE_ID",
                table: "PRODUCTS",
                column: "MAIN_STONE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_SUB_STONE_ID",
                table: "PRODUCTS",
                column: "SUB_STONE_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRODUCTS");
        }
    }
}
