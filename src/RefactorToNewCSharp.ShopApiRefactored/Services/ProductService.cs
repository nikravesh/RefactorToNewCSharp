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

    public void CategorizeProduct(Product product) =>
        Console.WriteLine(product.Price switch
        {
            < CheapCost => $"{product.Name} is Cheap",
            >= CheapCost and < NormalCost => $"{product.Name} is Normal",
            _ => $"{product.Name} is Expensive"
        });
}
