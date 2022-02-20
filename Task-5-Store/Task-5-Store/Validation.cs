using Task_5_Store.Models;
using Task_5_Store.Tools;

namespace Task_5_Store;

public class Validation
{
    private readonly Output _output;

    public Validation(Output output)
    {
        _output = output;
    }
    
    public bool IsAlreadyExists(User user, IEnumerable<User> users) => users.Contains(user);

    public bool CanBuyAlcohol(User user, Product product)
    {
        if (user.Age >= 18 || !product.Category.Equals("Alcohol")) return true;

        _output.PrintAlcoholProhibition(user);
        return false;

    }
}