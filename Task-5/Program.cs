using Store.Model;
using Store.Factory;
using Store;

public class StoreOps
{
    public static void Main(string[] args)
    {
        var service = new Service();
        var menu = new Menu();
        Console.WriteLine("Enter number of users to create");

        var usersCount = service.GetChoice();
        service.CreateListOfUsers(usersCount);
        menu.PrintOptions();
        
    }
}