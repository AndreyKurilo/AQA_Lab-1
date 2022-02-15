using JetBrains.Annotations;

namespace Task3_Drivers.Model;
[UsedImplicitly]
public class Person
{
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public bool IsDriver { [UsedImplicitly]get; set; }
}