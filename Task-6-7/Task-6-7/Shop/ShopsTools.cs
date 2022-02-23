using Task_6_7.Phones.Exceptions;
using Task_6_7.Phones.Models;
using Task_6_7.Shop.Models;

namespace Task_6_7.Shop;

public class ShopsTools
{
    private Output _output;

    public ShopsTools
    {
        _output = new Output();
    }

    public Dictionary<ShopDto, PhoneDto> GetPhonesByModel(ShopsDto shops, string phoneModel)
    {
        var phonesInShops = new Dictionary<ShopDto, PhoneDto>();

        foreach (ShopDto shop in shops.Shops)
        {
            foreach (PhoneDto phone in shop.Phones)
            {
                if (phone.Model == phoneModel)
                {
                    phonesInShops.Add(shop, phone);
                    break;
                }
            }
        }

        if (phonesInShops.Count == 0)
        {
            throw new PhoneNotFoundException();
        }
        else
        {
            _output.PrintPhonesAvailability(phonesInShops);
        }

        return phonesInShops;
    }

    public bool BuyPhone(Dictionary<ShopDto, PhoneDto> shopsList, string shopName)
    {
        foreach (var shops in shopsList)
        {
            PhoneDto phone = shops.Value;
            ShopDto shop = shops.Key;

            if (shop.Name != shopName) continue;
            Console.WriteLine($"Order for \"{phone.Model}\" total sum: {phone.Price} is made successfully!");
            return true;
        }

        return false;
    }
}