namespace Task3_Drivers.Model;

public abstract class Vehicle
{
    public string Model { get; set; }
    public int YearOfRelease { get; set; }
    public Driver Owner { get; protected set; }
    
    public Engine Engine { get; set; }
    
    public int MaxSpeed { get; set; }

    public abstract Driver SetOwner(Driver driver);
}