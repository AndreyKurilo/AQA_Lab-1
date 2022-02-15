using Bogus;
using Task3_Drivers.Factory;
using Task3_Drivers.Model;
using Person = Task3_Drivers.Model.Person;

namespace Task3_Drivers;

public static class Program
{
    private const int DriversCount = 3;

    public static void Main(string[] args)
    {
        var driverFactory = new DriverFactory2();
        var drivers = new List<Driver>();

        for (int i = 0; i < DriversCount; i++)
        {
            drivers.Add(driverFactory.Create());            
        }

        // Menu.AskForDriverNumber(DriversCount);
        // int driverNumber = Input.GetDriverNumber(DriversCount);
        // Menu.AskForTechnicalStats();
        // 
        
    }
}