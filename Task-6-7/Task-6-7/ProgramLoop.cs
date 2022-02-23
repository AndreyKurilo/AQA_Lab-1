using Task_6_7.Shop;
using Task_6_7.Shop.Models;

namespace Task_6_7;

public class ProgramLoop
{
    private readonly ShopsDto _shopsDto;

    public ProgramLoop(ShopsDto shopsDto)
    {
        _shopsDto = shopsDto;
    }
    
    public void Run()
    {
        var menu = new Menu();
        var condition = true;
        while (condition)
        {
            int userChoice = Int32.Parse(Console.ReadLine());
            condition = menu.Handle(_shopsDto, userChoice);
        }
    }
}