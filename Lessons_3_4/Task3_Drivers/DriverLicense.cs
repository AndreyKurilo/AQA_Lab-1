using Bogus;

namespace Task3_Drivers;

public class DriverLicense
{
    private DateTime dateDriverLicense;
    private Guid licenseID;

    public DriverLicense() {}
    
    public DriverLicense(DateTime dateOfBirth)
    {
        EstablishLicenseData(dateOfBirth);
        licenseID = new Guid();
    }

    private void EstablishLicenseData(DateTime dateOfBirth)
    {
        var faker = new Faker();
        if (DateTime.Now.Year - dateOfBirth.Year > 16)
        {
            dateDriverLicense = faker.Date.BetweenOffset(
                new DateTimeOffset(dateOfBirth), new DateTimeOffset(DateTime.Today)).Date;
        }
        else
        {
            Console.WriteLine("Person too young");
        }
    }
}