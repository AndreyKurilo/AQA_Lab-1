namespace Store.Model;

public class User
{
    public Guid PassportId { get; set; }

    private sealed class PassportIdEqualityComparer : IEqualityComparer<User>
    {
        public bool Equals(User x, User y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.PassportId.Equals(y.PassportId);
        }

        public int GetHashCode(User obj)
        {
            return obj.PassportId.GetHashCode();
        }
    }

    public static IEqualityComparer<User> PassportIdComparer { get; } = new PassportIdEqualityComparer();

    public string FullName { get; set; } = null!;
    public int Age { get; set; }
}