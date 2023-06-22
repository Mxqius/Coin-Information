using System.Globalization;

namespace CoinInformation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            typingPrint("Hello, Welcome to the CoinInformation!", 50);
            Console.WriteLine("\nLoading Information...");
            Thread.Sleep(1000);
            Console.Clear();
            CoinInfo coinInfo = new CoinInfo();
            CultureInfo cultureInfo = new CultureInfo("en-US");
            while (true)
            {
                List<Coin> coins = coinInfo.GetAllCoins().Result;

                foreach (Coin coin in coins)
                {
                    Console.WriteLine($"Name: {coin.Name}");
                    Console.WriteLine($"Symbol: {coin.Symbol}");
                    Console.WriteLine($"Price: {coin.CurrentPrice.ToString("C", cultureInfo)}");
                    Console.WriteLine($"Market Cap: {coin.MarketCap}");
                    Console.WriteLine();
                }
                Thread.Sleep(300_000);
                Console.Clear();
            }
            //Console.ReadKey();
        }

        static void typingPrint(string message, int delayMs)
        {
            foreach (char chr in message)
            {
                Console.Write(chr);
                Thread.Sleep(delayMs);
            }
        }
    }
}