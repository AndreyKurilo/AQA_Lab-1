using Bogus;
using Task3_Drivers.Model;
using Person = Task3_Drivers.Model.Person;

namespace Task3_Drivers.Factory;

public class DriverFactory
{
    private readonly Faker _faker;

    public DriverFactory()
    {
        _faker = new Faker();
    }

    public Driver Create(Person person)
    {
        var driver = new Driver();

        driver.Name = _faker.Name.FirstName();
        driver.Surname = _faker.Name.LastName();
        driver.DateOfBirth = person.DateOfBirth;
        driver.LicenseID = new Guid();
        driver.DateDriverLicense = ReleaseLicenseDate(person);
        driver.IsDriver = true;

        return driver;
    }

    private DateTime ReleaseLicenseDate( Person person)
    {
        DateTime startDate = person.DateOfBirth.AddYears(16);
        DateTime finishDate = DateTime.Now;
        DateTime date = _faker.Date.BetweenOffset(
            new DateTimeOffset(startDate), new DateTimeOffset(finishDate)).Date;

        return date;
    }

    private Driver EstablishLicenseData(DateTime dateOfBirth, Driver license)
    {
        var faker = new Faker();

        if (DateTime.Now.Year - dateOfBirth.Year > 16)
        {
            license.DateDriverLicense = faker.Date.BetweenOffset(
                new DateTimeOffset(dateOfBirth), new DateTimeOffset(DateTime.Today)).Date;
            return license;
        }
        else
        {
            Console.WriteLine("Person too young");
            return null;
        }
    }
}