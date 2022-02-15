namespace Task3_Drivers.Model;

public class Driver : Person
{
    public DateTime DateDriverLicense { get; set; }
    public Guid LicenseID { get; set; }

    public void PrintDriver(Driver driver)
    {
        Console.WriteLine("Surname: " + driver.Surname);
        Console.WriteLine("Name: " + driver.Name);
        Console.WriteLine("Age: " + (DateTime.Now.Year - driver.DateOfBirth.Year));
        Console.WriteLine("Date of release driver's license: " + driver.DateDriverLicense);
        Console.WriteLine("License ID: " + driver.LicenseID);
    }
}