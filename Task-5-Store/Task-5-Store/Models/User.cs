namespace Task_5_Store.Models;

public class User
{
    public int PassportId { get; }
    public string FullName { get; }
    public int Age { get; }

    public User(int passportId, string fullName, int age)
    {
        PassportId = passportId;
        FullName = fullName;
        Age = age;
    }

    private bool Equals(User other)
    {
        return PassportId.Equals(other.PassportId);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        
        return Equals((User) obj);
    }

    public override int GetHashCode() => PassportId.GetHashCode();
}