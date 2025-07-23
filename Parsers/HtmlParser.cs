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

                var availability = node.SelectSingleNode(".//p[contains(@class,'availability')]")
                                  ?.InnerText.Trim();

                var imageUrl = node.SelectSingleNode(".//img")
                                   ?.GetAttributeValue("src", "");

                if (!string.IsNullOrEmpty(imageUrl))
                {
                    // Convert to absolute URL
                    imageUrl = "https://books.toscrape.com/" + imageUrl.TrimStart('/');
                }

                var detailUrl = node.SelectSingleNode(".//h3/a")
                                    ?.GetAttributeValue("href", "");

                if (!string.IsNullOrEmpty(detailUrl))
                {
                    detailUrl = "https://books.toscrape.com/catalogue/" + detailUrl.TrimStart('/');
                }

                products.Add(new Product
                {
                    Name = name,
                    Price = price,
                    Availability = availability,
                    ImageUrl = imageUrl,
                    DetailPageUrl = detailUrl
                });
            }

            return products;
        }
    }

}
