using ShopApp.Data;
using ShopApp.Models;

namespace ShopApp.Services;
public class ProductService
{
    private readonly ShopDbContext _db;

    public ProductService(ShopDbContext db)
    {
        _db = db;
    }

    public void AddProduct(Product product)
    {
        _db.Products.Add(product);
        _db.SaveChanges();
    }

    public void CategorizeProduct(Product product)
    {
        if (product.Price < 100)
            Console.WriteLine($"{product.Name} is Cheap");
        else if (product.Price >= 100 && product.Price < 1000)
            Console.WriteLine($"{product.Name} is Normal");
        else
            Console.WriteLine($"{product.Name} is Expensive");
    }
}
