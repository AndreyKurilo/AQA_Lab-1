using Bogus;
using Store.Model;

namespace Store.Factory;

public class UserFactory
{
    private readonly Faker _faker;

    public UserFactory()
    {
        _faker = new Faker();
    }

    public User Create()
    {
        var randomNumber = new Random();
        var user = new User()
        {
            PassportId = Guid.NewGuid(),
            FullName = _faker.Name.FullName(),
            Age = randomNumber.Next(10, 100)
        };
        return user;
    }
    
    public static void PrintUsersList(List<User> users)
    {
        int counter = 0;
        Console.WriteLine("   List of users");
        Console.WriteLine("____________________________________________________________");
        foreach (var user in users)
        {
            counter++;
            Console.WriteLine(counter + " | " + user.FullName);
        }
    }
}
