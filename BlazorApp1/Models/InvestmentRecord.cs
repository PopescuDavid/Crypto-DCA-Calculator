namespace BlazorApp1.Models
{
    public class InvestmentRecord
    {
        public DateTime Date { get; set; }
        public decimal InvestedAmount { get; set; }
        public decimal CryptoAmount { get; set; }
        public decimal ValueToday { get; set; }
        public string CryptoSymbol { get; set; } // Add this property to store the symbol (BTC, ETH, etc.)
    }
}
