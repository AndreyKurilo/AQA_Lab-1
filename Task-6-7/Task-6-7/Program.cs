using Task_6_7.Shop;
using Task_6_7.Shop.Models;

namespace Task_6_7;

public static class Program
{
    public static void Main()
    {
        var output = new Output();
        const string filename = "appsettings.json";
        var doThis = new DoThis();

        ShopsDto shopsDto = doThis.TryConvertToShopsDto(filename);
        
        var loop = new ProgramLoop(shopsDto);

        output.MenuOptions();
        
        loop.Run();
    }
}