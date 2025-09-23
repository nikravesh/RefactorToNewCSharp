using RefactorToNewCSharp.ShopApiRefactored.Models;

using ShopApp.Data;

namespace ShopApp.Services;
public class ProductService (ShopDbContext db)
{
    public void AddProduct(Product product)
    {
        db.Products.Add(product);
        db.SaveChanges();
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
