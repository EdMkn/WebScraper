namespace WebScraper.Services
{
    public interface IScraperService
{
    Task ScrapeAsync(string url);
}

}