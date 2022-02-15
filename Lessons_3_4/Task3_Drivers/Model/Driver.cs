using Bogus;

namespace Task3_Drivers.Model;

public class Driver : Person
{
    public DateTime DateDriverLicense { get; set; }
    public Guid LicenseId { get; set; }
    public Vehicle Vehicle { get; set; } = null!;

    public void Print()
    {
        Console.WriteLine("Surname: " + Surname);
        Console.WriteLine("Name: " + Name);
        Console.WriteLine("Age: " + (DateTime.Now.Year - DateOfBirth.Year));
        Console.WriteLine("Date of release driver's license: " + DateDriverLicense);
        Console.WriteLine("License ID: " + LicenseId);
    }
}