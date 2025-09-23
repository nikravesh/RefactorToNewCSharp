using RefactorToNewCSharp.ShopApiRefactored.Models;

using ShopApp.Data;
using ShopApp.Services;

Product laptop = new("Laptop",10000);
Product book = new("Book", 100);

ProductService productService = new(new ShopDbContext());
await productService.AddProductAsync(book);
await productService.AddProductAsync(laptop);

await productService.SaveAsync();

productService.CategorizeProduct(book);
productService.CategorizeProduct(laptop);

Console.ReadKey();