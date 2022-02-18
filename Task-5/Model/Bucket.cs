using Store.Factory;

namespace Store.Model;

public class Bucket
{
    public User User { get; set; }
    private List<Product> _goods;
    private Product _product;

    public Bucket()
    {
        _goods = new List<Product>();
        var _product = new ProductFactory();
    }

    public void AddProduct()
    {
        _goods.Add(_product);
    }
}