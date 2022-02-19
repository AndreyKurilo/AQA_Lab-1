using Store.Factory;

namespace Store.Model;

public class Bucket
{
    private readonly User _user;
    private readonly List<Product> _goods;
    private Product _product;
    private const int startSet = 10;
    
    public Bucket(User user)
    {
        _user = user;
        _goods = new List<Product>();
        for (int i = 0; i < startSet; i++)
        {
            var productFactory = new ProductFactory();
            _product = productFactory.Create();
            AddProduct();
        }
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
            Console.WriteLine($"   {good.Category}    |       {good.Name}     |        ${Math.Round(good.Price, 2)}");
        }
        Console.WriteLine("\tTotal sum:   $" + Math.Round(sum,2));
        Console.WriteLine();
    }
}