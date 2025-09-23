using Microsoft.EntityFrameworkCore;

using RefactorToNewCSharp.ShopApiRefactored.Models;

using ShopApp.Data;
using ShopApp.Services;

namespace RefactorToNewCSharp.ShopApiRefactoredTest;

public class ProductServiceTests
{
    private ShopDbContext GetInMemoryDbContext() => new ShopDbContext();


    [Fact]
    public async Task AddProductAsync_ShouldAddProductToDatabase()
    {
        var db = GetInMemoryDbContext();
        var service = new ProductService(db);
        var product = new Product("Laptop", 1000);


        await service.AddProductAsync(product);
        await service.SaveAsync();


        var savedProduct = await db.Products.FirstOrDefaultAsync(p => p.Name == "Laptop");
        Assert.NotNull(savedProduct);
        Assert.Equal(1000, savedProduct.Price);
    }


    [Fact]
    public void GetProduct_ShouldReturnProductDto_WhenProductExists()
    {
        var db = GetInMemoryDbContext();
        var service = new ProductService(db);
        var product = new Product("Book", 50);


        service.AddProduct(product);
        service.Save();


        var dto = service.GetProduct(product.Id);


        Assert.NotNull(dto);
        Assert.Equal("Book", dto.Name);
        Assert.Equal(50, dto.Price);
    }


    [Fact]
    public async Task GetProductAsync_ShouldReturnProductDto_WhenProductExists()
    {
        var db = GetInMemoryDbContext();
        var service = new ProductService(db);
        var product = new Product("Pen", 5);


        await service.AddProductAsync(product);
        await service.SaveAsync();


        var dto = await service.GetProductAsync(product.Id);


        Assert.NotNull(dto);
        Assert.Equal("Pen", dto.Name);
        Assert.Equal(5, dto.Price);
    }


    [Fact]
    public void GetProduct_ShouldThrowException_WhenProductDoesNotExist()
    {
        var db = GetInMemoryDbContext();
        var service = new ProductService(db);


        var ex = Assert.Throws<Exception>(() => service.GetProduct(999));
        Assert.Equal("Product not found!", ex.Message);
    }


    [Fact]
    public void CategorizeProduct_ShouldWriteCorrectCategoryToConsole()
    {
        var db = GetInMemoryDbContext();
        var service = new ProductService(db);


        var cheapProduct = new Product("Cheap", 50);
        var normalProduct = new Product("Normal", 500);
        var expensiveProduct = new Product("Expensive", 5000);


        using var sw = new StringWriter();
        Console.SetOut(sw);


        service.CategorizeProduct(cheapProduct);
        service.CategorizeProduct(normalProduct);
        service.CategorizeProduct(expensiveProduct);


        var output = sw.ToString().Trim();
        Assert.Contains("Cheap is Cheap", output);
        Assert.Contains("Normal is Normal", output);
        Assert.Contains("Expensive is Expensive", output);
    }
}
