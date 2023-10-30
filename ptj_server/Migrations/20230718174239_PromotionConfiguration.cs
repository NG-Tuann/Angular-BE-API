using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ptj_server.Migrations
{
    /// <inheritdoc />
    public partial class PromotionConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PROMOTIONS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DISCOUNT_VALUE = table.Column<int>(type: "int", nullable: false),
                    DISCOUNT_UNIT = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    START_DATE = table.Column<DateTime>(type: "date", nullable: true),
                    END_DATE = table.Column<DateTime>(type: "date", nullable: true),
                    CODE = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    MAX_DISCOUNT = table.Column<int>(type: "int", nullable: true),
                    MIN_ORDER = table.Column<int>(type: "int", nullable: true),
                    ACTIVATE = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROMOTION", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PROMOTIONS");
        }
    }
}
