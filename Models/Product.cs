using System.ComponentModel.DataAnnotations;

namespace WebScraper.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; } // auto-incrément ID

        public string? Name { get; set; }
        public string? Price { get; set; }
        public string? Availability { get; set; }
        public string? ImageUrl { get; set; }
        public string? DetailPageUrl { get; set; }
        public override string ToString() =>
        $"{Name} | {Price} | {Availability}";
    }
}
