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

    public int GetChoice()
    {
        return Int32.Parse(Console.ReadLine());
    }

    public void AnalyzeChoice(int choice)
    {
        switch (choice)
        {
            case 1:
                UserFactory.PrintUsersList(_users);
                break;
            case 2:
                Console.WriteLine("Enter users number");
                GetChoice();
                var bucket = new Bucket(_users[choice - 1]);
                bucket.PrintListGoods();
                break;
            case 3:
                var newUser = _userFactory.Create();
                _users.Add(newUser);
                Console.WriteLine($"New user {newUser.FullName} created");
                break;
            case 4:
                Console.WriteLine("Enter user's number for bucket update");
                var userNumber = GetChoice();
                
                break;
            default:
                Console.WriteLine("Process stopped by You");
                break;
        }
    }
}