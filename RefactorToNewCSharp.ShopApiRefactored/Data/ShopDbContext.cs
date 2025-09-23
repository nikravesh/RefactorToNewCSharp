using Microsoft.EntityFrameworkCore;
using RefactorToNewCSharp.ShopApiRefactored.Data;
using RefactorToNewCSharp.ShopApiRefactored.Models;

namespace ShopApp.Data;
public class ShopDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>().Property<DateTime>("CreatedAt");
        modelBuilder.Entity<Product>().Property<int>("CreatedBy");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("ShopDb")
            .AddInterceptors(new LoggingInterceptor());
    }
}
