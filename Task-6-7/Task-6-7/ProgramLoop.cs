using Task_6_7.Phones.Models;
using Task_6_7.Shop;
using Task_6_7.Shop.Models;

namespace Task_6_7;

public class ProgramLoop
{
    private readonly ShopsDto _storesDto;

    public ProgramLoop(ShopsDto storesDto)
    {
        _storesDto = storesDto;
    }
    
    public void Run()
    {
        var output = new Output();
        var menu = new Menu();
        var condition = true;
        while (condition)
        {
            int userChoice = Int32.Parse(Console.ReadLine());
            condition = menu.Handle(_storesDto, userChoice);
            if (condition)
            {
                Console.WriteLine();
                output.MenuOptions();
            }
        }
    }
}