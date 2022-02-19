using Store.Factory;
using Store.Model;

namespace Store;

public class Service
{
    private List<User> _users;
    private UserFactory _userFactory;

    public Service()
    {
        var _userFactory = new UserFactory();

    }

    public void CreateListOfUsers(int usersCount)
    {
        for (int i = 0; i < usersCount; i++)
        {
            _users.Add(_userFactory.Create());
        }
    }

    public static  int GetChoice()
    {
        return Int32.Parse(Console.ReadLine());
    }

    public void HandlesChoice()
    {
        int choice;
        do
        {
            choice = GetChoice();

            switch (choice)
            {
                case 1:
                    UserFactory.PrintUsersList(_users);
                    break;
                case 2:
                    Console.WriteLine("Enter users number");
                    var bucket = new Bucket(_users[GetChoice() - 1]);
                    bucket.PrintListGoods();
                    break;
                case 3:
                    var newUser = _userFactory.Create();
                    if (Validate.Candidate(newUser, _users))
                    {
                        _users.Add(newUser);
                        Console.WriteLine($"New user {newUser.FullName} created");
                    }
                    else
                    {
                        Console.WriteLine("User with same ID already exists");
                    }
                    break;
                case 4:
                    Console.WriteLine("Enter user's number for bucket update");
                    var chosenUser = _users[GetChoice() - 1];
                    BucketsOperations(chosenUser);
                    break;
                default:
                    Console.WriteLine("Process stopped by You");
                    choice = 0;
                    break;
            }

            if (choice != 0) 
            {
                Menu.PrintOptions();
            }
        } while (choice != 0);
    }

    private void BucketsOperations(User user)
    {
        var bucket = new Bucket(user);
        bucket.PrintListGoods();
        Console.WriteLine("Would You like add(1) or remove(2) product");
        var choice = GetChoice();
        switch (choice)
        {
            case 1:
                var product = new ProductFactory().CreateDefiniteProduct();
                if (Validate.Aprove(user, product))
                {
                    bucket.Goods.Add(product);
                    Console.WriteLine($"Now bucket of {bucket.User.FullName} contains:");
                    bucket.PrintListGoods();
                }
                break;
            case 2:
                ChoseAndRemoveProduct(bucket);
                Console.WriteLine($"Now bucket of {bucket.User.FullName} contains:");
                bucket.PrintListGoods();
                break;
            default:
                Console.WriteLine("Wrong choice number, process stopped");
                break;
        }
    }

    private void ChoseAndRemoveProduct(Bucket bucket)
    {
        Console.WriteLine("What product You want to remove? - chose the number");
        var numberChosenProduct = GetChoice();
        var chosenProduct = bucket.Goods[numberChosenProduct - 1];
        Console.WriteLine($"{chosenProduct.Name} removing from the bucket...");
        bucket.RemoveProduct(numberChosenProduct);
    }
}