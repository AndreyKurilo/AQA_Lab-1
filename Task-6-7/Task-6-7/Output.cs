using Task_6_7.Model;

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