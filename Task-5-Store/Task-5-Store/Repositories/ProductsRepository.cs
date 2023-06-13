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
        foreach (Product newProduct in GetEachProduct())
        {
            _products.Add(newProduct);
        }
    }

    private IEnumerable<Product> GetEachProduct() =>
        from categoryProducts in _productsData.GetAssortment()
        from product in categoryProducts.Value
        select _productFactory.Create(categoryProducts.Key, product);

    public IEnumerable<Product> GetProducts() => _products;

    public Product GetProductByName(string productName)
    {
        Product? product = _products.Find(x => x.Name == productName);

        if (product == null) throw new NullReferenceException();

        return product;
    }
}