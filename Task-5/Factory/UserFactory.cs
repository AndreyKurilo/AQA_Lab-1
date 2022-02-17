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
        var user = new User()
        {
            PassportId = Guid.NewGuid(),
            FullName = _faker.Name.FullName(),
            Age = new Random().Next(10, 100)
        };
        return user;
    }
}
