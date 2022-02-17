using Bogus;

namespace Store.Model;

public class Product: DataSet
{
    private static readonly string[] Dairy =
    {
        "Cheese", "Milk", "Сottage cheese", "Yogurt", "Sour cream"
    };
    
    public string DairyProducts()
    {
        return Random.ArrayElement(Dairy);
    }

    
    private static readonly string[] Bakeries =
    {
        "Pie", "Cake", "Biscuit", "Bun", "Pastry"
    };
    
    public string Bakery()
    {
        return Random.ArrayElement(Bakeries);
    }
    

    private static readonly string[] Candies =
    {
        "Hard candy", "Taffy", "Chocolate bar", "Stick candy",
        "Jelly bean", "Mint", "Cotton candy", "Lollipop"
    };
    
    public string Candy()
    {
        return Random.ArrayElement(Candies);
    }
    

    private static readonly string[] Drinks = { "Soda", "Water", "Beer", "Wine", "Coffee", "Lemonade", "Milk" };
    
    public string Drink()
    {
        return Random.ArrayElement(Drinks);
    }
}