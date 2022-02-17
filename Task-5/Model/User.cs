namespace Store.Model;

public class User
{
    public Guid PassportId { get; set; }
    public string FullName { get; set; } = null!;
    public int Age { get; set; }
}