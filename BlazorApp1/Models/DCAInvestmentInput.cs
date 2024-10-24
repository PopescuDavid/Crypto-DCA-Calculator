namespace BlazorApp1.Models
{
    public class DCAInvestmentInput
    {
        public string CryptoSymbol { get; set; }
        public decimal MonthlyInvestmentAmount { get; set; }
        public DateTime StartDate { get; set; }
        public int DayOfMonth { get; set; }
    }
}
