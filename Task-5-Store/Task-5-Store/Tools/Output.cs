using Task_5_Store.Models;

namespace Task_5_Store.Tools;

public class Output
{
    public void PrintMenu()
    {
        Console.WriteLine(" Enter number of option You need");
        Console.WriteLine(" 1 - Display list of customers");
        Console.WriteLine(" 2 - Display customer bucket");
        Console.WriteLine(" 3 - Add new customer");
        Console.WriteLine(" 4 - Remove product");
        Console.WriteLine(" 5 - Add product");
        Console.WriteLine(" 0 - Exit");
    }

    public void PrintCustomers(IEnumerable<Customer> customers)
    {
        var index = 0;
        Console.WriteLine("\n   List of users");
        Console.WriteLine("____________________________________________________________");
        foreach (Customer customer in customers)
        {
            index++;
            Console.WriteLine(index + " | " + customer.FullName);
        }

        Console.WriteLine();
    }

    public void PrintNumberInputErrorMessage() => Console.WriteLine("Please, enter number\n");
    public void PrintLineInputErrorMessage() => Console.WriteLine("Wrong line format\n");
    public void PrintWrongMenuOperation() => Console.WriteLine("Unrecognized menu option\n");
    public void PrintGoodbyeMessage() => Console.WriteLine("You selected Exit, Goodbye!\n");
    public void PrintWrongIndexMessage() => Console.WriteLine("Wrong entered index!\n");
    public void PrintCustomerSelection() => Console.WriteLine("Select customer number:\n");

    public void PrintBucket(Bucket bucket, Customer customer)
    {
        double sum = 0;
        int count = 0;

        Console.WriteLine($"{customer.FullName}'s bucket content");
        Console.WriteLine("_________________________________________________________________________________");
        Console.WriteLine("|  {4} | \t{0} \t{1} \t{2} \t\t\t{1} \t{3} \t{1}", "Category ", "|", "Name", "Price",
            "Pos.");
        Console.WriteLine("_________________________________________________________________________________");

        foreach (Product product in bucket.GetProducts())
        {
            count++;
            sum += product.Price;
            Console.WriteLine(
                $"|  {count,-5}|   " +
                $"{product.Category,-15} \t| " +
                $"\t{product.Name,-20} \t| " +
                $"\t${Math.Round(product.Price, 2)} \t|");
        }

        Console.WriteLine("----------------------------------------------------------------------------------");

        Console.WriteLine("\t\t\t\t\t\t\tTotal sum:      $" + Math.Round(sum, 2));
        Console.WriteLine();
    }

    public void PrintAlcoholProhibition(User user) => Console.WriteLine($"{user.FullName} too young to buy alcohol");

    public void PrintSameUserIdMessage(User user) =>
        Console.WriteLine($"User with id {user.PassportId} is already exists!\n");

    public void PrintNumberInputInSpecificRangeMessage(int min, int max) =>
        Console.WriteLine($"Please, enter number in range {min} - {max}\n");

    public void PrintEnterNameMessage() => Console.WriteLine("Please, enter full name:\n");
    public void PrintEnterPassportIdMessage() => Console.WriteLine("Please, enter passport id:\n");
    public void PrintEnterAgeMessage() => Console.WriteLine("Please, enter age:\n");
}