using Store.Factory;

namespace Store.Model;

public class Bucket
{
    private User _user;
    private List<Product> _goods;
    private Product _product;
    
    public Bucket(User user)
    {
        _user = user;
        _goods = new List<Product>();
        var _product = new ProductFactory();
    }
    
    public Bucket(){}

    public User User { get; set; }
    public List<Product> Goods { get; set; }

    public void AddProduct()
    {
        _goods.Add(_product);
    }

    public void RemoveProduct(int index)
    {
        _goods.RemoveAt(index);
    }

    public void PrintListGoods()
    {
        double sum = 0;
        Console.WriteLine($"{0}'s bucket content ", _user.FullName);
        Console.WriteLine("_____________________________________________________________________");
        Console.WriteLine("         Category                   Name                Price        ");

        foreach (var good in _goods)
        {
            sum += good.Price;
            Console.WriteLine($"   {good.Category}    |       {good.Name}     |        ${good.Price}");
        }

        Console.WriteLine("                                               Total sum:   $" + sum);
    }
}