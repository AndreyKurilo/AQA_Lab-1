namespace Task3_Drivers.Model;

public class Truck : Vehicle
{
    public bool HasPricep { get; set; }
    
    public override void SetOwner(Driver owner)
    {
        Owner = owner;
    }
}