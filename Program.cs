using Microsoft.Extensions.DependencyInjection;
using WebScraper;
using WebScraper.Services;
using WebScraper.Parsers;
using WebScraper.Models;

var services = new ServiceCollection();

// Register services
services.AddHttpClient<IHttpClientService, HttpClientService>();
services.AddSingleton<IHtmlParser<Product>, HtmlParser>();
services.AddTransient<IScraperService, ScraperService>();

var serviceProvider = services.BuildServiceProvider();

var scraper = serviceProvider.GetRequiredService<IScraperService>();

string targetUrl = "https://books.toscrape.com/catalogue";
await scraper.ScrapeAsync(targetUrl, 50);
