using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ptj_server.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CUSTOMER_TYPES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CUSTOMER_TYPE_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DISCOUNT_VALUE = table.Column<int>(type: "int", nullable: true),
                    DISCOUNT_UNIT = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMER_TYPE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GEOMANCIES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GEOMANCY", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ROLES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CUSTOMERS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FULLNAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    USERNAME = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    PASSWORD = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    DOB = table.Column<DateTime>(type: "date", nullable: true),
                    ID_CARD = table.Column<string>(type: "char(12)", unicode: false, fixedLength: true, maxLength: 12, nullable: true),
                    CUSTOMER_TYPE_ID = table.Column<int>(type: "int", nullable: true),
                    SCORE_PAY = table.Column<int>(type: "int", nullable: true),
                    ADDRESS = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    PHONE = table.Column<string>(type: "char(12)", unicode: false, fixedLength: true, maxLength: 12, nullable: true),
                    AVATAR = table.Column<string>(type: "char(12)", unicode: false, fixedLength: true, maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMER", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CUSTOMER_TYPE",
                        column: x => x.CUSTOMER_TYPE_ID,
                        principalTable: "CUSTOMER_TYPES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USERNAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PASSWORD = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    FULLNAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DOB = table.Column<DateTime>(type: "date", nullable: false),
                    PHONE = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: true),
                    ID_CARD = table.Column<string>(type: "char(12)", unicode: false, fixedLength: true, maxLength: 12, nullable: true),
                    IdRole = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.Id);
                    table.ForeignKey(
                        name: "FK_USERS_ROLE",
                        column: x => x.IdRole,
                        principalTable: "ROLES",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMERS_CUSTOMER_TYPE_ID",
                table: "CUSTOMERS",
                column: "CUSTOMER_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USERS_IdRole",
                table: "USERS",
                column: "IdRole");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CUSTOMERS");

            migrationBuilder.DropTable(
                name: "GEOMANCIES");

            migrationBuilder.DropTable(
                name: "USERS");

            migrationBuilder.DropTable(
                name: "CUSTOMER_TYPES");

            migrationBuilder.DropTable(
                name: "ROLES");
        }
    }
}
