namespace Task_5_Store.Data;

public class ProductsData
{
    private readonly Dictionary<string, string[]> _assortment;

    public ProductsData()
    {
        _assortment = new Dictionary<string, string[]>
        {
            {"Dairy", _dairy},
            {"MeatProduct", _meatProduct},
            {"Fruit", _fruit},
            {"Vegetable", _vegetable},
            {"Bakery", _bakery},
            {"Candy", _candy},
            {"Drink", _drink},
            {"Alcohol", _alcohol}
        };
    }

    public IEnumerable<string> GetCategories() => _assortment.Keys;
    public IEnumerable<string> GetProductsNames(string categoryName) => _assortment[categoryName];

    private readonly string[] _dairy =
    {
        "Cheese", "Milk", "Сottage cheese", "Yogurt", "Sour cream"
    };

    private readonly string[] _meatProduct =
    {
        "Beef", "Pork", "Chicken", "Sausage", "Meatball"
    };

    private readonly string[] _fruit =
    {
        "Apples", "Pears", "Oranges", "Bananas", "Plums", "Peaches"
    };

    private readonly string[] _vegetable =
    {
        "cabbage", "beetroot", "Cucumber", "Potato", "Tomato", "Sweet pepper"
    };

    private readonly string[] _bakery =
    {
        "Pie", "Cake", "Biscuit", "Bun", "Pastry"
    };

    private readonly string[] _candy =
    {
        "Hard candy", "Taffy", "Chocolate bar", "Stick candy",
        "Jelly bean", "Mint", "Cotton candy", "Lollipop"
    };

    private readonly string[] _drink =
    {
        "Soda", "Juice", "Coffee", "Lemonade", "Milk", "Сocoa"
    };

    private readonly string[] _alcohol =
    {
        "Beer", "Wine", "Whisky", "Vodka"
    };
}