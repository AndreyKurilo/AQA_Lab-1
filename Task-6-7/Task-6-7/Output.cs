using Task_6_7.Phones.Models;
using Task_6_7.Shop.Models;

namespace Task_6_7;

public class Output
{
    public void RequestPhoneModel()
    {
        Console.WriteLine("What phones model would You like to bye?");
    }

    public void RequestShop()
    {
        Console.WriteLine("At what shop You are going to bye phone?");
    }

    public static void EnterOtherModel()
    {
        Console.WriteLine("Please enter other model");
    }

    public void MenuOptions()
    {
        Console.WriteLine("Chose the option You need:");
        Console.WriteLine(" 1 - display whole assortment ");
        Console.WriteLine(" 2 - display quantity available phones selected by OS type");
        Console.WriteLine(" 3 - specify phones's model You want to buy");
        Console.WriteLine(" 0 - for exit");
    }
    
    public void PrintPhonesAvailability(Dictionary<ShopDto, PhoneDto> phonesInShops)
    {
        foreach (var phoneInShop in phonesInShops)
        {
            PhoneDto phone = phoneInShop.Value;
            ShopDto shop = phoneInShop.Key;

            Console.WriteLine(phoneInShop.Value.IsAvailable == false
                ? $"{phone.Model} is not available in {shop.Name}"
                : $"You can purchase {phone.Model} in {shop.Name}");
        }
    }

    public void PrintFoundPhone(Dictionary<ShopDto, PhoneDto> phonesInShops)
    {
        foreach (var phoneInShop in phonesInShops)
        {
            PhoneDto phone = phoneInShop.Value;
            ShopDto shop = phoneInShop.Key;

            Console.WriteLine($"In \"{shop.Name}\" this model \"{phone.Model}\" costs {phone.Price}");
        }
    }

    public void ShowShopsAssortment(ShopsDto shopsDto)
    {
        foreach (ShopDto shopData in shopsDto.Shops)
        {
            Console.WriteLine($"\nThis shop with ID {shopData.Id} " +
                              $"and name \"{shopData.Name}\" has such assortment:");
            foreach (PhoneDto phoneData in shopData.Phones)
            {
                Console.WriteLine($"Model: {phoneData.Model}  OStype: {phoneData.OperationSystemType}");
            }
        }

    }

    public void AvailablePnones(List<ShopDto> shops)
    {
        
        foreach (ShopDto shopData in shops)
        {
            var iosCount = 0;
            var androidCount = 0;

            foreach (PhoneDto phoneData in shopData.Phones)
            {
                if (phoneData.OperationSystemType.Equals("IOS") && phoneData.IsAvailable)
                {
                    iosCount++;
                }
                else
                {
                    if (phoneData.OperationSystemType.Equals("Android") && phoneData.IsAvailable)
                    {
                        androidCount++;
                    }
                }
            }

            Console.WriteLine($"\n{shopData.Id} \"{shopData.Name}\" offers:");
            Console.WriteLine($"\t{iosCount} IOS models and {androidCount} Android models");
        }
    }
}