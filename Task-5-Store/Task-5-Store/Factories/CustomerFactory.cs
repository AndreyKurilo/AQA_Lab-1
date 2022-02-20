using Bogus;
using Task_5_Store.Models;

namespace Task_5_Store.Factories;

public class CustomerFactory
{
    private readonly Faker _faker;

    public CustomerFactory()
    {
        _faker = new Faker();
    }

    public Customer Create()
    {
        var random = new Random();
        
        var customer = new Customer(
            Guid.NewGuid(), 
            _faker.Name.FullName(), 
            random.Next(10, 100));
  
        return customer;
    }
}