using Bogus;
using Store.Model;

namespace Store.Factory;

public class ProductFactory : DataSet
{
    private Product _product;
    private Faker _faker;
    private const int priceMin = 1;
    private const int priceMax = 20;


    public ProductFactory()
    {
        _product = new Product();
        _faker = new Faker();
    }

    public Product Create()
    {
        _product.Category = Category();
        var productsInThisCategory = categories[_product.Category];
        _product.Name = _faker.PickRandom(productsInThisCategory);
        _product.Price = _faker.Random.Float(priceMin, priceMax);

        return _product;
    }

    public Product CreateDefiniteProduct()
    {
        _product.Category = GetCategory();
        _product.Name = GetProductName(categories[_product.Category]);
        _product.Price = _faker.Random.Float(priceMin, priceMax);

        return null;
    }

    private string GetCategory()
    {
        Console.WriteLine("Enter category: ");
        int counter = 0;
        foreach (var categoryName in categories)
        {
            Console.WriteLine($"{counter++}. {categoryName}");
        }
        
        var inputCategoryName = Console.ReadLine();
        while (!categories.ContainsKey(inputCategoryName))
        {
            Console.WriteLine("Wrong input category, reenter please");
            inputCategoryName = Console.ReadLine();
        }

        return inputCategoryName;
    }

    private string GetProductName(string[] categoryGoods)
    {
        int choice;
        do
        {
            Console.WriteLine("Chose number of the product you want to add");
            int counter = 0;
            foreach (var productName in categoryGoods)
            {
                Console.WriteLine($"{counter++}. {productName}");
            }

            choice = Service.GetChoice();

        } while (choice >= 1 || choice <= categoryGoods.Length);
        
        return categoryGoods[choice - 1];
    }

    private readonly Dictionary<string, string[]> categories = new Dictionary<string, string[]>()
    {
        {"Dairy", Dairy}, {"MeatProduct", MeatProduct}, {"Fruit", Fruit}, {"Vegetable", Vegetable},
        {"Bakery", Bakery}, {"Candy", Candy}, {"Drink", Drink}, {"Alcohol", Alcohol}
    };


    private static readonly string[] Categories =
    {
        "Dairy", "MeatProduct", "Fruit", "Vegetable", "Bakery", "Candy", "Drink", "Alcohol"
    };

    public string Category()
    {
        return _faker.PickRandom(Categories);
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
        "Beef", "Pork", "Chicken", "Sausage", "Meatball"
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
        "Soda", "Juice",  "Coffee", "Lemonade", "Milk",  "Сocoa"
    };

    public string Drinks()
    {
        return Random.ArrayElement(Drink);
    }
    
    private static readonly string[] Alcohol =
    {
        "Beer", "Wine",  "Whisky", "Vodka"
    };

    public string Alcoholic()
    {
        return Random.ArrayElement(Drink);
    }

}