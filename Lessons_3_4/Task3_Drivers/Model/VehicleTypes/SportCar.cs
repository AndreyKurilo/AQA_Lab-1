namespace Task3_Drivers.Model;

public class SportCar : Vehicle
{
    public override Driver SetOwner(Driver driver)
    {
        if (HasDrivingExperience(driver))
        {
            return driver;
        }

        Console.WriteLine($"{0} {1} not allowed to drive sport car because of shortage expirience",
            driver.Name, driver.Surname);
        return null;
    }

    private bool HasDrivingExperience(Driver driver)
    {
        if ((DateTime.Now.Year - driver.DateDriverLicense.Year) > 5)
        {
            return true;
        }
        return false;
    }
}