using System.Xml;
using Json.Net;
using Task_6_7.Phones.Exceptions;
using Task_6_7.Phones.Models;
using Task_6_7.Shop.Models;

namespace Task_6_7;

public class JsonHandler
{
    public static string jsonText;
    public ShopsDto TryConvertToShopsDto(string filename)
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
    
    public string SerializeData(Dictionary<ShopDto, PhoneDto> storesList, string storeName)
    {
        var invoice = new InvoceDto();
        string output = null;
        
        foreach (var stores in storesList)
        {
            PhoneDto phone = stores.Value;
            ShopDto store = stores.Key;

            if (store.Name != storeName) continue;
            invoice.PhoneModel = phone.Model;
            invoice.StoreName = store.Name;
            invoice.Price = phone.Price;

            output = JsonNet.Serialize(invoice);
        }

        return output;
    }
    
    
    
    public PhoneDto GetPhoneLinq(ShopsDto shops, string phoneModel)
    {
        PhoneDto phone;

        try
        {
            phone = shops.Shops
                .SelectMany(x => x.Phones)
                .Single(x => x.Model == phoneModel);
        }
        catch (InvalidOperationException)
        {
            throw new PhoneNotFoundException();
        }

        return phone;
    }

    public void SearchModelInShopList(ShopsDto shops, string phoneModel)
    {
        bool searchSuccess = false;

        foreach (ShopDto shopData in shops.Shops)
        {
            Console.WriteLine($"Result of searching in {shopData.Name}:");

            foreach (PhoneDto phoneData in shopData.Phones)
            {
                if (phoneData.Model.Contains(phoneModel))
                {
                    Console.WriteLine($"This model {phoneData.Model} is in the shop's list");

                    var availablePhones = shopData.Phones.FindAll(x => x.IsAvailable);
                    
                    if (PhoneModelIsAvailable(shops, shopData.Name, phoneModel))
                    {
                        Console.WriteLine($"Model {phoneData.Model} is available");
                        searchSuccess = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Model {phoneData.Model} is NOT available");
                        Output.EnterOtherModel();
                        break;
                    }
                }
                else
                {
                    Console.WriteLine($"Model {phoneData.Model} not present at the {shopData.Name}'s list");
                }
            }
        }

        if (!searchSuccess)
        {
            Output.EnterOtherModel();
        }
    }

    public bool PhoneModelIsAvailable(ShopsDto shops, string shopName, string phoneModel)
    {
        foreach (ShopDto shop in shops.Shops)
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