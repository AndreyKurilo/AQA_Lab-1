namespace Task3_Drivers;

public class Menu
{
    public int AskDriversNumber()
    {
        int numberOfDrivers;
        
        Console.WriteLine("Enter number of drivers");
        numberOfDrivers = Int32.Parse(Console.ReadLine());
        return numberOfDrivers;
    }
    
    
}