namespace Task3_Drivers.Model.VehicleTypes;

public class Minivan : Vehicle
{
    public int Seats { get; set; }
    public override Driver SetOwner(Driver driver)
    {
        Owner = driver;
        return driver;
    }
}