using Task_6_7.Phones.Models;
using Task_6_7.Shop;
using Task_6_7.Shop.Models;

namespace Task_6_7;

public class Menu
{

    public bool Handle(ShopsDto shopsDto, int userChoice)
    {
        var input = new Input();
        var output = new Output();
        var storesTools = new StoresTools();
        var jsonSerializer = new JsonHandler();
        var condition = true;

        switch (userChoice)
        {
            case 1:
                output.ShowShopsAssortment(shopsDto);
                break;
            case 2:
                output.AvailablePnones(shopsDto.Shops);
                break;
            case 3:
                var chosenModel = input.GetPhoneModel();
                var storesList = storesTools.GetPhonesByModel(shopsDto, chosenModel);
                output.PrintFoundPhone(storesList);
                var storeName = input.GetStoreName();
                condition = storesTools.BuyPhone(storesList, storeName);
                if (condition)
                {
                    JsonHandler.jsonText = jsonSerializer.SerializeData(storesList, storeName);
                }
                break;
            default:
                condition = false;
                break;
        }

        return condition;
    }
}