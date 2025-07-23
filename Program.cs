using Microsoft.Extensions.DependencyInjection;
using WebScraper;
using WebScraper.Services;
using WebScraper.Parsers;
using WebScraper.Models;
using WebScraper.Data;

var services = new ServiceCollection();

// Register services
services.AddHttpClient<IHttpClientService, HttpClientService>();
services.AddSingleton<IHtmlParser<Product>, HtmlParser>();
services.AddTransient<IScraperService, ScraperService>();
services.AddDbContext<ScraperDbContext>();

var serviceProvider = services.BuildServiceProvider();

var scraper = serviceProvider.GetRequiredService<IScraperService>();

string targetUrl = "https://books.toscrape.com/catalogue";
await scraper.ScrapeAsync(targetUrl, 50);
