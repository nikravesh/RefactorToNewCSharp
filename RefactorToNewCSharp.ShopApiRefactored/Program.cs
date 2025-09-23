using RefactorToNewCSharp.ShopApiRefactored.Models;

using ShopApp.Data;
using ShopApp.Services;

Product laptop = new("Laptop",10000);
Product book = new("Book", 100);

ProductService productService = new(new ShopDbContext());
productService.AddProduct(book);
productService.AddProduct(laptop);

productService.Save();

productService.CategorizeProduct(book);
productService.CategorizeProduct(laptop);

Console.ReadKey();