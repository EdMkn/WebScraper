namespace WebScraper.Models
{
    public class Product
    {
        public string? Name { get; set; }
        public string? Price { get; set; }

        public override string ToString() => $"{Name} - {Price}";
    }
}
