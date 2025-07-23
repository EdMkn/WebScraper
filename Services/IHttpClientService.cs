namespace WebScraper.Services
{
    public interface IHttpClientService
    {
        Task<string> GetHtmlAsync(string url);
    }
}

