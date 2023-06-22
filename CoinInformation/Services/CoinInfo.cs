using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

public class CoinInfo
{
    private readonly HttpClient _httpClient;

    public CoinInfo()
    {
        HttpClientHandler handler = new HttpClientHandler
        {
            Proxy = new WebProxy("46.4.96.137", 1080),
            UseProxy = true
        };

        _httpClient = new HttpClient();

        _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
    }

    public async Task<List<Coin>> GetAllCoins()
    {
        List<Coin> coins = new List<Coin>();

        try
        {
            string apiUrl = "https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&order=market_cap_desc&per_page=10&page=1"; // CoinGecko API endpoint
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();
            coins = JsonConvert.DeserializeObject<List<Coin>>(responseContent);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving coin information: {ex.Message}");
        }

        return coins;
    }
}

public class Coin
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    [JsonProperty("current_price")]
    public decimal CurrentPrice { get; set; }

    [JsonProperty("market_cap")]
    public decimal MarketCap { get; set; }
    // Add more properties as needed
}

