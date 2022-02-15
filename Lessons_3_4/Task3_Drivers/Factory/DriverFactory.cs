using Bogus;
using Task3_Drivers.Model;

namespace Task3_Drivers.Factory;

public class DriverFactory2
{
    private readonly Faker _faker;

    public DriverFactory2()
    {
        _faker = new Faker();
    }

    public Driver Create()
    {
        var driver = new Driver
        {
            Name = _faker.Name.FirstName(),
            Surname = _faker.Name.LastName(),
            DateOfBirth = GetDateOfBirth(),
            LicenseID = new Guid()
        };

        driver.DateDriverLicense = GetDateDriverLicense(driver.DateOfBirth);
        driver.IsDriver = true;

        return driver;
    }

    private DateTime GetDateDriverLicense(DateTime dateOfBirth)
    {
        DateTime startDate = dateOfBirth.AddYears(21);
        DateTime finishDate = DateTime.Now;
        DateTime date = _faker.Date.BetweenOffset(
            new DateTimeOffset(startDate), new DateTimeOffset(finishDate)).Date;

        return date;
    }

    private DateTime GetDateOfBirth()
    {
        DateTime date = _faker.Date.BetweenOffset(
            new DateTimeOffset(DateTime.Now.AddYears(-100)), 
            new DateTimeOffset(DateTime.Now.AddYears(-23))).Date;

        return date;
    }
}