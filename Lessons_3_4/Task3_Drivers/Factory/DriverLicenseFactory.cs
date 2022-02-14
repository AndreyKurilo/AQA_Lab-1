using Bogus;

namespace Task3_Drivers;

public class DriverLicenseFactory
{
    
    public DriverLicenseFactory(DateTime dateOfBirth)
    {
        var driverLicense = new DriverLicense();
        if (EstablishLicenseData(dateOfBirth, driverLicense) != null)
        {
            driverLicense.LicenseID = new Guid();
        }
    }

    private DriverLicense EstablishLicenseData(DateTime dateOfBirth, DriverLicense license)
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