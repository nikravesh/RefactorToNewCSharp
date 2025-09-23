namespace RefactorToNewCSharp.ShopApiRefactored.Models;
public class Product( string name, decimal price)
{
    public int Id { get; init; }
    public string Name { get; init; } = name;
    public decimal Price { get; init; } = price;
}
