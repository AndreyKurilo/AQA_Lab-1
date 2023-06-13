namespace Task_5_Store.Models;

public class Customer : User
{
    public Bucket Bucket { get; }

    public Customer(int passportId, string fullName, int age) : base(passportId, fullName, age)
    {
        Bucket = new Bucket();
    }
}