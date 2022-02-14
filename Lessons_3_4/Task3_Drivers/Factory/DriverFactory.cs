using Bogus;
using Task3_Drivers.Model;

namespace Task3_Drivers.Factory;

public class DriverFactory
{
    private readonly Faker _faker;

    public DriverFactory()
    {
        _faker = new Faker();
    }

    public Driver Create()
    {
        var driver = new Driver();

        driver.Name = _faker.Name.FirstName();
        driver.Surname = _faker.Name.LastName();
        driver.DateOfBirth = EstablishDate();
        driver.LicenseID = new Guid();
        driver.DateDriverLicense = _faker.Date.Between(driver.DateOfBirth + 16, DateTime.Now);
        driver.IsDriver = true;

        return driver;
    }

    private DateTime EstablishDate()
    {
        DateTime startDate = DateTime.Parse("10/01/1954");
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