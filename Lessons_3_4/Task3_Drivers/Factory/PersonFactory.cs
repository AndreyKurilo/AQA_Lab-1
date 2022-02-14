using Bogus;
using Person = Task3_Drivers.Model.Person;

namespace Task3_Drivers.Factory;

public class PersonFactory
{
    private readonly Faker _faker;

    public PersonFactory()
    {
        _faker = new Faker();
    }
    
    public Person Create()
    {
        var person = new Person();
        
        person.Name = _faker.Name.FirstName();
        person.Surname = _faker.Name.LastName();
        person.DateOfBirth = EstablishDate();
        //person.IsDriver = _driverFactory.Create(person.DateOfBirth) != null;

        return person;
    }

    private DateTime EstablishDate()
    {
        DateTime startDate = DateTime.Parse("10/01/1954");
        DateTime finishDate = DateTime.Now;

        DateTime date = _faker.Date.BetweenOffset(
            new DateTimeOffset(startDate), new DateTimeOffset(finishDate)).Date;

        return date;
    }
}