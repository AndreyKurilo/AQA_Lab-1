namespace Task3_Drivers.Model.VehicleTypes;

public class Truck : Vehicle
{
    public bool HasPricep { get; set; }
    
    public override Driver SetOwner(Driver driver)
    {
        Owner = driver;
        return driver;
    }
}