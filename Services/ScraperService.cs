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

        public async Task ScrapeAsync(string url)
        {
            Console.WriteLine($"Scraping URL: {url}");

            string html = await _httpClient.GetHtmlAsync(url);
            Console.WriteLine("HTML fetched.");

            var products = _parser.Parse(html);
            Console.WriteLine($"Parsed {products.Count()} products.");

            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }
    }

}