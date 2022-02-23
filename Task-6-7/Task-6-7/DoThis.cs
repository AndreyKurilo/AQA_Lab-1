using System.Xml;
using Json.Net;
using Task_6_7.Model;

namespace Task_6_7;

public class DoThis
{
    public ShopsDto ReadJsonFile(string filename)
    {
        var path = Path.Combine(Environment.CurrentDirectory, @"Data\", filename);
        // https://stackoverflow.com/questions/816566/how-do-you-get-the-current-project-directory-from-c-sharp-code-when-creating-a-c

        string json;

        try
        {
            json = File.ReadAllText(path);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found.");
            return null;
        }
        catch (IOException)
        {
            Console.WriteLine("Something went wrong on file reading.");
            return null;
        }

        return JsonNet.Deserialize<ShopsDto>(json);
    }

    public void SearchModelInShopList(ShopsDto shops, string phoneModel)
    {
        foreach (ShopDto shopData in shops.Shops)
        {
            Console.WriteLine($"Result of searching in {shopData.Name}:");

            foreach (PhoneDto phoneData in shopData.Phones)
            {
                if (phoneData.Model.Contains(phoneModel))
                {
                    Console.WriteLine($"This model {phoneData.Model} is in the shop's list");
                    if (PhoneModelIsAvailable(shops, shopData.Name, phoneModel))
                    {
                        
                    }
                }
            }
        }
    }

    public bool PhoneModelIsAvailable(ShopsDto shops, string shopName, string phoneModel)
    {
        foreach (ShopDto shop  in shops.Shops)
        {
            if (shop.Name.Equals(shopName))
            {
                foreach (var phone in shop.Phones)
                {
                    if (phone.Model.Equals(phoneModel))
                    {
                        if (phone.IsAvailable)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
        }
        return false;
    }
}