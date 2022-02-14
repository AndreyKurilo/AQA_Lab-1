namespace Task3_Drivers;

public class Vehicle
{
    public string Model { get; set; }
    public string Type { get; set; }
    public int YearOfRelease { get; set; }
    public Person Owner { get; set; }
    public Engine Engine { get; set; }
}