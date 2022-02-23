using Task_6_7.Phones.Exceptions;
using Task_6_7.Phones.Models;
using Task_6_7.Shop.Models;

namespace Task_6_7.Shop;

public class StoresTools
{
    private Output _output;

    public StoresTools()
    {
        _output = new Output();
    }

    public Dictionary<ShopDto, PhoneDto> GetPhonesByModel(ShopsDto stores, string phoneModel)
    {
        var phonesInShops = new Dictionary<ShopDto, PhoneDto>();

        foreach (ShopDto store in stores.Shops)
        {
            foreach (PhoneDto phone in store.Phones)
            {
                if (phone.Model == phoneModel)
                {
                    phonesInShops.Add(store, phone);
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

    public bool BuyPhone(Dictionary<ShopDto, PhoneDto> storesList, string storeName)
    {
        foreach (var stores in storesList)
        {
            PhoneDto phone = stores.Value;
            ShopDto store = stores.Key;

            if (store.Name != storeName) continue;
            Console.WriteLine($"Order for \"{phone.Model}\" total sum: {phone.Price} is made successfully!");
            return false;
        }

        return true;
    }

    public async void MakeInvoice(string jsonText)
    {
        string filename = "note.json";
        string path = Path.Combine(Environment.CurrentDirectory, @"Data\", filename);
        
        using (StreamWriter writer = new StreamWriter(path, false))
        {
            await writer.WriteLineAsync(jsonText);
        }
    }
}