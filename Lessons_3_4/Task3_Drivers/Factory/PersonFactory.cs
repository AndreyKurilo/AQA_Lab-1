using Bogus;

namespace Task3_Drivers;

public class PersonFactory
{
    public Person create()
    {
        var person = new Person();
        var faker = new Faker();
        
        person.Name = faker.Name.FirstName();
        person.Surname = faker.Name.LastName();
        person.DateOfBirth = EstablishDate();
        person.Driver = new DriverLicenseFactory(person.DateOfBirth).Equals(null);

        return person;
    }

    private DateTime EstablishDate()
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