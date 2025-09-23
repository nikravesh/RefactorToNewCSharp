using Microsoft.EntityFrameworkCore;

using ShopApp.Models;

namespace ShopApp.Data;
public class ShopDbContext : DbContext
{
    public DbSet<Product> Products {  get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseInMemoryDatabase("ShopDb")
            .AddInterceptors(new LoggingInterceptor());
    }
}
