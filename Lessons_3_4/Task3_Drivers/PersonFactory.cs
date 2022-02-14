using Bogus;

namespace Task3_Drivers;

public class PersonFactory
{
    public Person create()
    {
        var person = new Person();
        
        person.Name = new Faker().Name.FirstName();
        person.Surname = new Faker().Name.LastName();
        person.DateOfBirth = establishDate();
        person.Driver = new DriverLicense(person.DateOfBirth).Equals(null);

        return person;
    }

    private DateTime establishDate()
    {
        var faker = new Faker();
            
        DateTime startDate = DateTime.Parse("10/01/1954");
        DateTime finishDate = DateTime.Now;
        DateTime date;

        date = faker.Date.BetweenOffset(
            new DateTimeOffset(startDate), new DateTimeOffset(finishDate)).Date;
        
        throw new NotImplementedException();

        return date;
    }
}