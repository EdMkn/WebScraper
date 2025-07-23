using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using WebScraper.Models;
using WebScraper.Parsers;
namespace WebScraper.Services
{


    public class ScraperService : IScraperService
    {
        private readonly IHttpClientService _httpClient;
        private readonly IHtmlParser<Product> _parser;

        public ScraperService(IHttpClientService httpClient, IHtmlParser<Product> parser)
        {
            _httpClient = httpClient;
            _parser = parser;
        }

        public async Task ScrapeAsync(string baseUrl, int pageCount)
        {
            var allProducts = new List<Product>();

            for (int i = 1; i <= pageCount; i++)
            {
                string pageUrl = $"{baseUrl}/page-{i}.html";
                Console.WriteLine($"Scraping page {i}: {pageUrl}");

                string html;
                try
                {
                    html = await _httpClient.GetHtmlAsync(pageUrl);

                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"⚠️  Erreur HTTP à la page {i}: {ex.Message}");
                    continue; // passe à la suivante
                }


                var products = _parser.Parse(html).ToList();
                if (products.Count == 0)
                {
                    Console.WriteLine("🚫 Aucune donnée sur cette page. Fin du scraping.");
                    break;
                }
                Console.WriteLine($"Parsed {products.Count} products.");

                allProducts.AddRange(products);
                /*foreach (var product in products)
                {
                    Console.WriteLine(product);
                }*/


            }


            // Export JSON
            var json = JsonSerializer.Serialize(allProducts, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync("products_all.json", json);

            Console.WriteLine("✅ Export JSON -> products_all.json");
        }
    }

}