using ShopApp.Data;
using ShopApp.Models;
using ShopApp.Services;

class Program
{
    static void Main()
    {
        using var db = new ShopDbContext();
        var service = new ProductService(db);

        var laptop = new Product { Name = "Laptop", Price = 1200 };
        var book = new Product { Name = "Book", Price = 50 };

        service.AddProduct(laptop);
        service.AddProduct(book);

        service.CategorizeProduct(laptop);
        service.CategorizeProduct(book);
    }
}
