namespace Task3_Drivers.Model;

public class SportCar : Vehicle
{
    public override void SetOwner(Driver owner)
    {
        if (HasDrivingExperience(owner))
        {
            Owner = owner;
        }
    }

    private bool HasDrivingExperience(Driver owner)
    {
        return true;
    }
}