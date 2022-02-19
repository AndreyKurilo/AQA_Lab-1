using Store.Model;
using Store.Factory;
using Store;

public class StoreOps
{
    public static void Main(string[] args)
    {
        var service = new Service();
        Console.WriteLine("Enter number of users to create");
        var usersCount = Service.GetChoice();
        
        service.CreateListOfUsers(usersCount);
        
        Menu.PrintOptions();
        service.HandlesChoice();
    }
}