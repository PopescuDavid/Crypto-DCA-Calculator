using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cryptos",
                columns: table => new
                {
                    CryptoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cryptos", x => x.CryptoId);
                });

            migrationBuilder.CreateTable(
                name: "DCAInvestments",
                columns: table => new
                {
                    DCAInvestmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MonthlyInvestmentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CryptoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DCAInvestments", x => x.DCAInvestmentId);
                    table.ForeignKey(
                        name: "FK_DCAInvestments_Cryptos_CryptoId",
                        column: x => x.CryptoId,
                        principalTable: "Cryptos",
                        principalColumn: "CryptoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvestmentRecords",
                columns: table => new
                {
                    InvestmentRecordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvestedAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CryptoAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValueToday = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DCAInvestmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestmentRecords", x => x.InvestmentRecordId);
                    table.ForeignKey(
                        name: "FK_InvestmentRecords_DCAInvestments_DCAInvestmentId",
                        column: x => x.DCAInvestmentId,
                        principalTable: "DCAInvestments",
                        principalColumn: "DCAInvestmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DCAInvestments_CryptoId",
                table: "DCAInvestments",
                column: "CryptoId");

            migrationBuilder.CreateIndex(
                name: "IX_InvestmentRecords_DCAInvestmentId",
                table: "InvestmentRecords",
                column: "DCAInvestmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvestmentRecords");

            migrationBuilder.DropTable(
                name: "DCAInvestments");

            migrationBuilder.DropTable(
                name: "Cryptos");
        }
    }
}
