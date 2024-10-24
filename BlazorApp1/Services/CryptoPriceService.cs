using BlazorApp1.Models;
using Newtonsoft.Json.Linq;

namespace BlazorApp1.Services
{
    public class CryptoPriceService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public CryptoPriceService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["CoinMarketCapApiKey"]; // Store API key in appsettings.json
        }

        public async Task<List<InvestmentRecord>> CalculateDCA(List<DCAInvestmentInput> investments)
        {
            var investmentRecords = new List<InvestmentRecord>();

            foreach (var investment in investments)
            {
                var cryptoPrice = await GetCryptoPrice(investment.CryptoSymbol);
                var currentDate = investment.StartDate;

                decimal totalCryptoAmount = 0;
                decimal totalInvested = 0;

                while (currentDate <= DateTime.Today)
                {
                    decimal investedAmount = investment.MonthlyInvestmentAmount;
                    decimal cryptoAmount = investedAmount / cryptoPrice;
                    totalCryptoAmount += cryptoAmount;
                    totalInvested += investedAmount;

                    var record = new InvestmentRecord
                    {
                        Date = currentDate,
                        InvestedAmount = Math.Round(investedAmount, 2),
                        CryptoAmount = cryptoAmount,
                        ValueToday = totalCryptoAmount * cryptoPrice,
                        CryptoSymbol = investment.CryptoSymbol
                    };

                    investmentRecords.Add(record);
                    currentDate = currentDate.AddMonths(1);
                }
            }

            return investmentRecords;
        }


        public async Task<decimal> GetCryptoPrice(string symbol)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://pro-api.coinmarketcap.com/v1/cryptocurrency/quotes/latest?symbol={symbol}")
            };

            request.Headers.Add("X-CMC_PRO_API_KEY", _apiKey);

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            var json = JObject.Parse(result);

            return json["data"][symbol]["quote"]["USD"]["price"].Value<decimal>();
        }

        public async Task<List<CompetingCryptoPerformance>> ComparePerformance(List<string> topCoins)
        {
            var performances = new List<CompetingCryptoPerformance>();

            foreach (var coin in topCoins)
            {
                var currentPrice = await GetCryptoPrice(coin);

                var performance = new CompetingCryptoPerformance
                {
                    CryptoSymbol = coin,
                    CurrentPrice = currentPrice,
                    TotalInvestmentValue = currentPrice * 100 // Example logic
                };

                performances.Add(performance);
            }

            return performances;
        }
    }
}
