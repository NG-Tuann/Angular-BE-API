using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ptj_server.Migrations
{
    /// <inheritdoc />
    public partial class OrderProductConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_CUSTOMERS_CustomerId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_PRODUCTS_ProductId",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Review",
                table: "Review");

            migrationBuilder.RenameTable(
                name: "Review",
                newName: "REVIEWS");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "REVIEWS",
                newName: "TITLE");

            migrationBuilder.RenameColumn(
                name: "Rate",
                table: "REVIEWS",
                newName: "RATE");

            migrationBuilder.RenameColumn(
                name: "Is_Update",
                table: "REVIEWS",
                newName: "IS_UPDATE");

            migrationBuilder.RenameColumn(
                name: "Created_Date",
                table: "REVIEWS",
                newName: "CREATED_DATE");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "REVIEWS",
                newName: "CONTENT");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "REVIEWS",
                newName: "PRODUCT_ID");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "REVIEWS",
                newName: "CUSTOMER_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Review_ProductId",
                table: "REVIEWS",
                newName: "IX_REVIEWS_PRODUCT_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Review_CustomerId",
                table: "REVIEWS",
                newName: "IX_REVIEWS_CUSTOMER_ID");

            migrationBuilder.AlterColumn<string>(
                name: "TITLE",
                table: "REVIEWS",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED_DATE",
                table: "REVIEWS",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CONTENT",
                table: "REVIEWS",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_REVIEW",
                table: "REVIEWS",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ORDER_PRODUCTS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DATE_CREATED = table.Column<DateTime>(type: "date", nullable: true),
                    CUSTOMER_ID = table.Column<int>(type: "int", nullable: true),
                    ADDRESS_DELIVERY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DATE_PAY = table.Column<DateTime>(type: "date", nullable: true),
                    PAY_TYPE = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TOTAL_PAY = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ORDER_STATE = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PHONE_NON_ACCOUNT = table.Column<string>(type: "char(12)", unicode: false, fixedLength: true, maxLength: 12, nullable: false),
                    NAME_CUS_NON_ACCOUNT = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SHIP_DATE = table.Column<DateTime>(type: "date", nullable: true),
                    SHIP_FEE = table.Column<int>(type: "int", nullable: true),
                    ID_USER = table.Column<int>(type: "int", nullable: true),
                    MAIL_NON_CUS = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PROMOTION_ID = table.Column<int>(type: "int", nullable: true),
                    CUSTOMER_TYPE_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDER_PRODUCT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ORDER_PRODUCTS_CUSTOMERS",
                        column: x => x.CUSTOMER_ID,
                        principalTable: "CUSTOMERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ORDER_PRODUCTS_USERS",
                        column: x => x.ID_USER,
                        principalTable: "USERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PromotionOrder",
                        column: x => x.PROMOTION_ID,
                        principalTable: "PROMOTIONS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_PRODUCTS_CUSTOMER_ID",
                table: "ORDER_PRODUCTS",
                column: "CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_PRODUCTS_ID_USER",
                table: "ORDER_PRODUCTS",
                column: "ID_USER");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_PRODUCTS_PROMOTION_ID",
                table: "ORDER_PRODUCTS",
                column: "PROMOTION_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_REVIEWS_CUSTOMERS",
                table: "REVIEWS",
                column: "CUSTOMER_ID",
                principalTable: "CUSTOMERS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_REVIEWS_PRODUCTS",
                table: "REVIEWS",
                column: "PRODUCT_ID",
                principalTable: "PRODUCTS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_REVIEWS_CUSTOMERS",
                table: "REVIEWS");

            migrationBuilder.DropForeignKey(
                name: "FK_REVIEWS_PRODUCTS",
                table: "REVIEWS");

            migrationBuilder.DropTable(
                name: "ORDER_PRODUCTS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_REVIEW",
                table: "REVIEWS");

            migrationBuilder.RenameTable(
                name: "REVIEWS",
                newName: "Review");

            migrationBuilder.RenameColumn(
                name: "TITLE",
                table: "Review",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "RATE",
                table: "Review",
                newName: "Rate");

            migrationBuilder.RenameColumn(
                name: "IS_UPDATE",
                table: "Review",
                newName: "Is_Update");

            migrationBuilder.RenameColumn(
                name: "CREATED_DATE",
                table: "Review",
                newName: "Created_Date");

            migrationBuilder.RenameColumn(
                name: "CONTENT",
                table: "Review",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "PRODUCT_ID",
                table: "Review",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "CUSTOMER_ID",
                table: "Review",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_REVIEWS_PRODUCT_ID",
                table: "Review",
                newName: "IX_Review_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_REVIEWS_CUSTOMER_ID",
                table: "Review",
                newName: "IX_Review_CustomerId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Review",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Date",
                table: "Review",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Review",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Review",
                table: "Review",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_CUSTOMERS_CustomerId",
                table: "Review",
                column: "CustomerId",
                principalTable: "CUSTOMERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_PRODUCTS_ProductId",
                table: "Review",
                column: "ProductId",
                principalTable: "PRODUCTS",
                principalColumn: "Id");
        }
    }
}
