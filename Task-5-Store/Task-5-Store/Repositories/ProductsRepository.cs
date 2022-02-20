using Task_5_Store.Data;
using Task_5_Store.Factories;
using Task_5_Store.Models;

namespace Task_5_Store.Repositories;

public class ProductsRepository
{
    private readonly ProductFactory _productFactory;
    private readonly ProductsData _productsData;
    private readonly List<Product> _products = new();

    public ProductsRepository(ProductsData productsData, ProductFactory productFactory)
    {
        _productsData = productsData;
        _productFactory = productFactory;

        CreateProducts();
    }

    private void CreateProducts()
    {
        foreach (var categoryProducts in _productsData.GetAssortment())
        {
            foreach (var product in categoryProducts.Value)
            {
                Product newProduct = _productFactory.Create(categoryProducts.Key, product);
                _products.Add(newProduct);
            }
        }
    }

    public IEnumerable<Product> GetProducts() => _products;
}