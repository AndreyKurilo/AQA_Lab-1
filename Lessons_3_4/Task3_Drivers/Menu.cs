using Task3_Drivers.Model;

namespace Task3_Drivers;

public class Menu
{
    public int AskDriversNumberToCreate()
    {
        int numberOfDrivers;
        
        Console.WriteLine("Enter number of drivers");
        numberOfDrivers = Int32.Parse(Console.ReadLine());
        return numberOfDrivers;
    }

    public Driver PickDriver(List<Driver> drivers)
    {
        do
        {
            Console.WriteLine($"Choose driver from the list (1-{0}", drivers.Count);
            int choice = Int32.Parse(Console.ReadLine());
            if (choice > 0 && choice <= drivers.Count)
            {
                return drivers[choice];
            }
        } while (true);
    }

    public int PickTechicalStat()
    {
        do
        {
            Console.WriteLine("Choose specificity You need to know from this roster:");
            Console.WriteLine("1 - Model;\n 2 - Year of production;\n 3 - Engine capacity;\n" +
                              "4 - Engine consumption;\n 5 - Max speed");
            int choice = Int32.Parse(Console.ReadLine());
            if (choice > 0 && choice <= 6)
            {
                return choice;
            }
        } while (true);
    }

    public int PickConsumtionInformation()
    {
        do
        {
            Console.WriteLine("Choose specificity You need to know from this roster:");
            Console.WriteLine("1 - Driver's experience;\n 2 - Fuel consumption;\n 3 - Time for trip;" );
            int choice = Int32.Parse(Console.ReadLine());
            if (choice > 0 && choice <= 4)
            {
                return choice;
            }
        } while (true);
    }
}