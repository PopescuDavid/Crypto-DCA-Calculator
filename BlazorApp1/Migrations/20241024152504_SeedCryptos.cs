using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorApp1.Migrations
{
    /// <inheritdoc />
    public partial class SeedCryptos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cryptos",
                columns: new[] { "CryptoId", "CurrentPrice", "Name", "Symbol" },
                values: new object[,]
                {
                    { 1, 0m, "Bitcoin", "BTC" },
                    { 2, 0m, "Ethereum", "ETH" },
                    { 3, 0m, "Ripple", "XRP" },
                    { 4, 0m, "Solana", "SOL" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cryptos",
                keyColumn: "CryptoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cryptos",
                keyColumn: "CryptoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cryptos",
                keyColumn: "CryptoId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cryptos",
                keyColumn: "CryptoId",
                keyValue: 4);
        }
    }
}
