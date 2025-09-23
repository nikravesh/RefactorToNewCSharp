using Microsoft.EntityFrameworkCore;

using RefactorToNewCSharp.ShopApiRefactored.Dto;
using RefactorToNewCSharp.ShopApiRefactored.Models;

using ShopApp.Data;

namespace ShopApp.Services;
public class ProductService(ShopDbContext db)
{
    private const int CheapCost = 100;
    private const int NormalCost = 1000;
    public void AddProduct(Product product) => db.Add(product);

    public async Task AddProductAsync(Product product) => await db.AddAsync(product);

    public ProductDto GetProduct(int id)
    {
        var product = db.Products.FirstOrDefault(p => p.Id == id);

        if (product is not null)
            return ToDto(product);

        throw new Exception("Product not found!");
    }

    public async Task<ProductDto> GetProductAsync(int id)
    {
        var product = await db.Products.FirstOrDefaultAsync(p => p.Id == id);

        if (product is not null)
            return ToDto(product);

        throw new Exception("Product not found!");
    }
    public void Save() => db.SaveChanges();

    public Task SaveAsync() => db.SaveChangesAsync();

    public void CategorizeProduct(Product product) =>
        Console.WriteLine(product.Price switch
        {
            < CheapCost => $"{product.Name} is Cheap",
            >= CheapCost and < NormalCost => $"{product.Name} is Normal",
            _ => $"{product.Name} is Expensive"
        });

    private ProductDto ToDto(Product product)
        => new(product.Name, product.Price);
}
