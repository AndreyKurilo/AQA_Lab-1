using Task3_Drivers.Model;

namespace Task3_Drivers;

public class Menu
{
    public void PrintDrivers(List<Driver> drivers)
    {
        for (var i = 0; i < drivers.Count; i++)
        {
            Driver driver = drivers[i];
            Console.WriteLine($"Driver #{i + 1}");
            driver.Print();
            Console.WriteLine(string.Empty);
        }
    }

    public int AskDriversCountToCreate()
    {
        Console.WriteLine("Enter number of drivers");
        var driversCount = Int32.Parse(Console.ReadLine());
        return driversCount;
    }

    public Driver PickDriver(List<Driver> drivers)
    {
        do
        {
            Console.WriteLine($"Choose driver from the list (1-{drivers.Count})");
            int choice = Int32.Parse(Console.ReadLine());
            if (choice > 0 && choice <= drivers.Count)
            {
                return drivers[choice - 1];
            }
        } while (true);
    }

    public VehicleDetailsType PickVehicleInformationType()
    {
        do
        {
            Console.WriteLine(@"Enter 1 for display vehicle technical details or  
                                2 to display consumption information");
            int choice = Int32.Parse(Console.ReadLine());
            if (choice < 1 && choice > 2)
            {
                Console.WriteLine("Wrong choice.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    return VehicleDetailsType.TechnicalDetails;
                default:
                    return VehicleDetailsType.ConsumptionDetails;
            }
        } while (true);
    }

    public int AskForDistance()
    {
        do
        {
            Console.WriteLine("Enter distance to ride: ");
            int distance = Int32.Parse(Console.ReadLine());

            if (distance <= 0)
            {
                Console.WriteLine("Distance can't be below 0");
                continue;
            }

            return distance;
        } while (true);
    }
}