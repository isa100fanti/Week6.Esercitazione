using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Week6.Esercitazione.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    CF = table.Column<string>(type: "nchar(16)", fixedLength: true, maxLength: 16, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.CF);
                });

            migrationBuilder.CreateTable(
                name: "Policy",
                columns: table => new
                {
                    Number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfSign = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsuredAmount = table.Column<double>(type: "float", nullable: false),
                    MonthlyRate = table.Column<double>(type: "float", nullable: false),
                    CFClient = table.Column<string>(type: "nchar(16)", nullable: true),
                    Policy_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgeClient = table.Column<int>(type: "int", nullable: true),
                    Plate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Displacement = table.Column<int>(type: "int", nullable: true),
                    PercentageCovered = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policy", x => x.Number);
                    table.ForeignKey(
                        name: "FK_Policy_Client_CFClient",
                        column: x => x.CFClient,
                        principalTable: "Client",
                        principalColumn: "CF",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Policy_CFClient",
                table: "Policy",
                column: "CFClient");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Policy");

            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
