using Task_6_7.Shop;
using Task_6_7.Shop.Models;

namespace Task_6_7;

public static class Program
{
    public static void Main()
    {
        var output = new Output();
        const string filename = "appsettings.json";
        var menu = new Menu();
        var doThis = new DoThis();
        var shopsTools = new StoresTools();

        ShopsDto shopsDto = doThis.TryConvertToShopsDto(filename);

         output.ShowShopsAssortment(shopsDto);
        //
        // output.AvailablePnones(shopsDto.Shops);

        var phonesInShops = shopsTools
            .GetPhonesByModel(shopsDto, "Samsung Galaxy S9");

        output.PrintPhonesAvailability(phonesInShops);
    }
}