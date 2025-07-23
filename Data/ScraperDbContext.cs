using Microsoft.EntityFrameworkCore;
using WebScraper.Models;

namespace WebScraper.Data
{
    public class ScraperDbContext : DbContext
    {
        public DbSet<Product> Products => Set<Product>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=scraper.db");
        }
    }
}
