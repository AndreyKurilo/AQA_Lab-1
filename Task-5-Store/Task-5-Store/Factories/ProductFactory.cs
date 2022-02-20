using Bogus;
using Task_5_Store.Data;
using Task_5_Store.Models;

namespace Task_5_Store.Factories;

public class ProductFactory
{
    private readonly ProductsData _productData;
    private readonly Faker _faker;
    private const int PriceMin = 1;
    private const int PriceMax = 20;
    private int _created;

    public ProductFactory(ProductsData productData)
    {
        _productData = productData;
        _faker = new Faker();
        _created = 0;
    }

    public Product CreateRandom()
    {
        _created++;
        
        var product = new Product();

        var category = _faker.PickRandom(_productData.GetCategories());
        var productName = _faker.PickRandom(_productData.GetProductsNames(category));
        
        product.Category = category;
        product.Name = productName;
        product.Price = _faker.Random.Float(PriceMin, PriceMax);
        product.Id = _created;

        return product;
    }
}