namespace Task_5_Store.Models;

public class Bucket
{
    private readonly List<Product> _products = new();

    public void AddProduct(Product product) => _products.Add(product);

    public bool RemoveProduct(int index)
    {
        if (index < 0 || index >= _products.Count) return false;
        
        _products.RemoveAt(index);
        
        return true;
    }

    public IEnumerable<Product> GetProducts() => _products;
}