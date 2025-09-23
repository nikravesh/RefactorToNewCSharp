using RefactorToNewCSharp.ShopApiRefactored.Models;

using ShopApp.Data;

namespace ShopApp.Services;
public class ProductService(ShopDbContext db)
{
    private const int CheapCost = 100;
    private const int NormalCost = 1000;
    public void AddProduct(Product product) => db.Add(product);

    public async Task AddProductAsync(Product product) => await db.AddAsync(product);

    public void Save() => db.SaveChanges();

    public Task SaveAsync() => db.SaveChangesAsync();

    public void CategorizeProduct(Product product)
    {
        if (product.Price < CheapCost)
            Console.WriteLine($"{product.Name} is Cheap");
        else if (product.Price >= CheapCost && product.Price < NormalCost)
            Console.WriteLine($"{product.Name} is Normal");
        else
            Console.WriteLine($"{product.Name} is Expensive");
    }
}
