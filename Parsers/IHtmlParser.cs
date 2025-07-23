namespace WebScraper.Parsers
{
    public interface IHtmlParser<T>
{
    IEnumerable<T> Parse(string html);
}
}

