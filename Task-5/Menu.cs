using Store.Model;
using Store.Factory;
using Store;

namespace Store;

public class Menu
{
    public static void PrintOptions()
    {
        Console.WriteLine(" Enter number of option You need");
        Console.WriteLine(" 1 - display list of buyers");
        Console.WriteLine(" 2 - display buyer's list of purchases");
        Console.WriteLine(" 3 - add new buyer");
        Console.WriteLine(" 4 - remove chosen product from thr bucket");
        Console.WriteLine(" 0 - Exit");
    }
}