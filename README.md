NOTE: NO REFACTORINGS AND CORRECTIONS MADE

How to Run the Application


1. Clone the Repository
bash
Copy code
git clone https://github.com/your-repository/crypto-dca-calculator.git
cd crypto-dca-calculator

3. Configure the Database
Ensure that your SQL Server is running and set up with the appropriate connection string in appsettings.json.

Connection String Example (appsettings.json)

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=CryptoDCA;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
  "CoinMarketCapApiKey": "YOUR_COINMARKETCAP_API_KEY"
}

Server: Replace YOUR_SERVER_NAME with your SQL Server instance name.
Database: The database name (CryptoDCA) will be created when you run migrations.
Trusted_Connection: If you are using integrated Windows authentication, keep this as True. Otherwise, use the User ID and Password options in the connection string if using SQL authentication.

3. Set Up the CoinMarketCap API Key
To fetch live cryptocurrency prices, you need to provide your CoinMarketCap API key.

Once you have your API key, replace YOUR_COINMARKETCAP_API_KEY in the appsettings.json file with your actual API key.
4. Run Database Migrations
You need to run the migrations to set up the database and seed the initial cryptocurrency data.

bash
Copy code
dotnet ef database update
This will create the database and seed the cryptocurrencies (Bitcoin, Ethereum, Ripple, Solana) with placeholder prices (you'll fetch the real-time prices from the API).

5. Run the Application
Now that your configuration and database are ready, you can run the application:

6. Access the Application

7. Features and Scenarios
Basic Scenario
The user selects one cryptocurrency (e.g., Bitcoin) and invests monthly (e.g., 200 EUR) from the selected start date (e.g., January 1st this year).
Intermediate Scenario
The user invests in multiple cryptocurrencies (e.g., BTC, ETH, SOL, XRP) with a set monthly amount (e.g., 200 EUR split equally), and the app displays the performance.
Advanced Scenario
The user can invest different amounts in multiple cryptocurrencies, starting at different times (e.g., 100 EUR in Bitcoin from January 1st last year, 150 EUR in Ethereum from January 1st this year).
Advanced 2 Scenario
The user can compare their investments with other top cryptocurrencies (e.g., BNB, DOGE) and view their performance side by side.
Notes
Database Seeding: The application seeds initial cryptocurrencies (Bitcoin, Ethereum, Ripple, Solana) with placeholder prices (0), and prices are updated using the API during the DCA calculation.
Pricing Data: Prices are fetched in real-time from the CoinMarketCap API using the provided API key.
No Authentication: The app does not include any login/register features as per the project scope.
