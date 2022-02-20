using Bogus;
using Task_5_Store.Models;

namespace Task_5_Store.Factories;

public class CustomerFactory
{
    private readonly Faker _faker;
    private int _created;

    public CustomerFactory()
    {
        _faker = new Faker();
        _created = 0;
    }

    public Customer CreateRandom()
    {
        _created++;
        var random = new Random();
        
        var customer = new Customer(
            _created, 
            _faker.Name.FullName(), 
            random.Next(10, 100));
  
        return customer;
    }

    public Customer Create(int passportId, string fullname, int age)
    {
        var customer = new Customer(passportId, fullname, age);
        return customer;
    }
}