using Bogus;
using Task3_Drivers.Factory;
using Task3_Drivers.Model;

namespace Task3_Drivers;

public static class Program
{
    public static void Main(string[] args)
    {
        var driverFactory = new DriverFactory();

        Driver firstDriver = driverFactory.Create();
        Driver secondDriver = driverFactory.Create();
        Driver thirdDriver = driverFactory.Create();
    }
}