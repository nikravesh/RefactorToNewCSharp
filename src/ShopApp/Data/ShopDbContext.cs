using Microsoft.EntityFrameworkCore;

using ShopApp.Models;

namespace ShopApp.Data;
public class ShopDbContext : DbContext
{
    public DbSet<Product> Products {  get; set; }
}
