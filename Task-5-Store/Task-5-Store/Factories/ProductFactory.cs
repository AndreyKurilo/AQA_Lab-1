using Bogus;
using Task_5_Store.Models;

namespace Task_5_Store.Factories;

public class ProductFactory
{
    private readonly Faker _faker;
    private const int PriceMin = 1;
    private const int PriceMax = 20;
    private int _created;

    public ProductFactory()
    {
        _faker = new Faker();
        _created = 0;
    }

    public Product Create(string productCategory, string productName)
    {
        _created++;
        
        var product = new Product
        {
            Category = productCategory,
            Name = productName,
            Price = Math.Round(_faker.Random.Float(PriceMin, PriceMax), 2),
            
            Id = _created
        };

        return product;
    }
}