using BlazorApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Data
{
    public class CryptoDCAContext : DbContext
    {
        public CryptoDCAContext(DbContextOptions<CryptoDCAContext> options)
            : base(options)
        {
        }

        public DbSet<Crypto> Cryptos { get; set; }
        public DbSet<InvestmentRecord> InvestmentRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Crypto>().HasData(
            new Crypto { CryptoId = 1, Name = "Bitcoin", Symbol = "BTC", CurrentPrice = 0 },  // You'll update the price with API
            new Crypto { CryptoId = 2, Name = "Ethereum", Symbol = "ETH", CurrentPrice = 0 }, // You'll update the price with API
            new Crypto { CryptoId = 3, Name = "Ripple", Symbol = "XRP", CurrentPrice = 0 },   // You'll update the price with API
            new Crypto { CryptoId = 4, Name = "Solana", Symbol = "SOL", CurrentPrice = 0 }    // You'll update the price with API
        );
        }
    }
}
