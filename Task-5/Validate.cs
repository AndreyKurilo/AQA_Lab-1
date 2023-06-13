using Bogus;
using Store.Model;

namespace Store;

public class Validate
{
    public static bool Candidate(User newUser, List<User> users)
    {
        foreach (var user in users)
        {
            if (user.Equals(newUser))
            {
                return false;
            }
        }

        return true;
    }

    public static bool Aprove(User user, Product product)
    {
        if (user.Age < 18 && product.Category.Equals("Alcohol"))
        {
            Console.WriteLine($"{user.FullName} too young to buy alcohol");
            return false;
        }

        return true;
    }
}