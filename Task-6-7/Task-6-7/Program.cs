using Json.Net;
using Task_6_7;
using Task_6_7.Model;

public static class Program
{
    public static void Main()
    {
        var output = new Output();
        const string filename = "appsettings.json";
        var action = new DoThis();
        
        ShopsDto shopsDto = action.ReadJsonFile(filename);
        
        output.ShowShopsAssortment(shopsDto);
        
        output.AvailablePnones(shopsDto.Shops);
    }
}