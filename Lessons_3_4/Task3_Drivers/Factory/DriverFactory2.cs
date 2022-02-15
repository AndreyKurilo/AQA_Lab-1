using Bogus;
using Task3_Drivers.Model;
using Person = Bogus.Person;

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
        var driver = new Driver();

        driver.Name = _faker.Name.FirstName();
        driver.Surname = _faker.Name.LastName();
        driver.DateOfBirth = GetDateOfBirth();
        driver.LicenseID = new Guid();
        driver.DateDriverLicense = GetDateDriverLicense(driver.DateOfBirth);
        driver.IsDriver = true;

        return driver;
    }

    private DateTime GetDateDriverLicense(DateTime dateOfBirth)
    {
        DateTime startDate = dateOfBirth.AddYears(16);
        DateTime finishDate = DateTime.Now;
        DateTime date = _faker.Date.BetweenOffset(
            new DateTimeOffset(startDate), new DateTimeOffset(finishDate)).Date;

        return date;
    }

    private DateTime GetDateOfBirth()
    {
        var date = new DateTime();
        date = _faker.Date.BetweenOffset(
            new DateTimeOffset(DateTime.Now.AddYears(-100)), 
            new DateTimeOffset(DateTime.Now.AddYears(-17))).Date;

        return date;
    }

    private DateTime ReleaseLicenseDate( Person person)
    {
        DateTime startDate = person.DateOfBirth.AddYears(16);
        DateTime finishDate = DateTime.Now;
        DateTime date = _faker.Date.BetweenOffset(
            new DateTimeOffset(startDate), new DateTimeOffset(finishDate)).Date;

        return date;
    }
}