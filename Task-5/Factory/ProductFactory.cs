using Bogus;
using Store.Model;

namespace Store.Factory;

public class ProductFactory: DataSet
{
            private Product _product;

    public ProductFactory()
    {
        _product = new Product();
    }

    public Product Create()
    {
        _product.Category = Category();
        string[] names =  categories[_product.Category];
        _product.Name = Random.ArrayElement(names);
        int 
        int priceMax = 50;
        Random rnd = new Random(priceMax);
        _product.Price = (float) rnd.NextDouble();
        
        return null;
    }

    private readonly Dictionary<string,string[]> categories = new Dictionary<string, string[]>()
    {
        {"Dairy", Dairy}, {"MeatProduct", MeatProduct}, {"Fruit", Fruit}, {"Vegetable", Vegetable},
        {"Bakery", Bakery}, {"Candy", Candy}, {"Drink", Drink}
    };
    

    private static readonly string[] Categories =
    {
        "Dairy", "MeatProduct", "Fruit", "Vegetable", "Bakery", "Candy", "Drink"
    };

    public string Category()
    {
        return Random.ArrayElement(Categories);
    }


    private static readonly string[] Dairy =
    {
        "Cheese", "Milk", "Сottage cheese", "Yogurt", "Sour cream"
    };

    public string DairyProducts()
    {
        return Random.ArrayElement(Dairy);
    }


    private static readonly string[] MeatProduct =
    {
        "Beef", "Pork", "Сhicken", "Sausage", "Meatball"
    };

    public string MeatProducts()
    {
        return Random.ArrayElement(MeatProduct);
    }


    private static readonly string[] Fruit =
    {
        "Apples", "Pears", "Oranges", "Bananas", "Plums", "Peaches"
    };

    public string Fruites()
    {
        return Random.ArrayElement(Fruit);
    }


    private static readonly string[] Vegetable =
    {
        "cabbage", "beetroot", "Cucumber", "Potato", "Tomato", "Sweet pepper"
    };

    public string Vegetables()
    {
        return Random.ArrayElement(Vegetable);
    }


    private static readonly string[] Bakery =
    {
        "Pie", "Cake", "Biscuit", "Bun", "Pastry"
    };

    public string Bakeries()
    {
        return Random.ArrayElement(Bakery);
    }


    private static readonly string[] Candy =
    {
        "Hard candy", "Taffy", "Chocolate bar", "Stick candy",
        "Jelly bean", "Mint", "Cotton candy", "Lollipop"
    };

    public string Candies()
    {
        return Random.ArrayElement(Candy);
    }


    private static readonly string[] Drink =
    {
        "Soda", "Water", "Beer", "Wine", "Coffee", "Lemonade", "Milk"
    };

    public string Drinks()
    {
        return Random.ArrayElement(Drink);
    }

}