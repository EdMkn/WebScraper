namespace WebScraper.Services
{
    using System.Net.Http;

public class HttpClientService(HttpClient client) : IHttpClientService
{
    private readonly HttpClient _client = client;

        public async Task<string> GetHtmlAsync(string url)
    {
        var response = await _client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}

}