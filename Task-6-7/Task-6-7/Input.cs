namespace Task_6_7;

public class Input
{
    public int GetChoice()
    {
        return Int32.Parse(Console.ReadLine());
    }

    public string GetPhoneModel()
    {
        Console.WriteLine("Enter phone's model");
        
        return Console.ReadLine();
    }

    public string GetStoreName()
    {
        Console.WriteLine("Enter store name");
        return Console.ReadLine();
    }
}