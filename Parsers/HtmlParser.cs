using HtmlAgilityPack;
using WebScraper.Models;

namespace WebScraper.Parsers
{
    public class HtmlParser : IHtmlParser<Product>
    {
        public IEnumerable<Product> Parse(string html)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            var products = new List<Product>();

            var nodes = doc.DocumentNode.SelectNodes("//article[@class='product_pod']");

            if (nodes == null) return products;

            foreach (var node in nodes)
            {
                //Console.WriteLine($"HTML fetched. {node}");
                var name = node.SelectSingleNode(".//h3/a")?.GetAttributeValue("title", "").Trim();

                var price = node.SelectSingleNode(".//div[@class='product_price']/p[@class='price_color']")
                    ?.InnerText.Trim();

                products.Add(new Product
                {
                    Name = name,
                    Price = price
                });
            }

            return products;
        }
    }

}
