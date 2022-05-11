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
        var person = new Person
        {
            Name = _faker.Name.FirstName(),
            Surname = _faker.Name.LastName(),
            DateOfBirth = EstablishDate()
        };

        person.IsDriver = ReleasePermission(person);

        return person;
    }
    
    private bool ReleasePermission(Person person) => 
        person.DateOfBirth.AddYears(16).Year <= DateTime.Now.Year;

    private DateTime EstablishDate()
    {
        DateTime startDate = DateTime.Now.AddYears(-100);
        DateTime finishDate = DateTime.Now;

        DateTime date = _faker.Date.BetweenOffset(
            new DateTimeOffset(startDate), new DateTimeOffset(finishDate)).Date;

        return date;
    }
}