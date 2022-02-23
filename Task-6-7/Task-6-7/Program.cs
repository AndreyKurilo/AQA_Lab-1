using Task_6_7.Shop;
using Task_6_7.Shop.Models;

namespace Task_6_7;

public static class Program
{
    public static void Main()
    {
        const string filename = "appsettings.json";

        var output = new Output();
        var jsonHandler = new JsonHandler();
        var storeTools = new StoresTools();

        ShopsDto shopsDto = jsonHandler.TryConvertToShopsDto(filename);
        
        var programLoop = new ProgramLoop(shopsDto);

        output.MenuOptions();
        
        programLoop.Run();
        
        storeTools.MakeInvoice(JsonHandler.jsonText);
    }
}