using Json.Net;
using Task_6_7;
using Task_6_7.Model;

public static class Program
{
    public static void Main()
    {
        var path = Path.Combine(Environment.CurrentDirectory, @"Data\", "appsettings.json");

        string json;
        
        try
        {
            json = File.ReadAllText(path);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found");
            return;
        }
        catch (IOException)
        {
            Console.WriteLine("Something went wrong on file reading");
            return;
        }

        var shopsDto = JsonNet.Deserialize<ShopsDto>(json);

        foreach (ShopDto shopData in shopsDto.Shops)
        {
            foreach (PhoneDto phoneData in shopData.Phones)
            {
                Console.WriteLine($"Model: {phoneData.Model}  OStype: {phoneData.OperationSystemType}");
            }
        }
    }
}