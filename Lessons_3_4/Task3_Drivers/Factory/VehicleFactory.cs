using Bogus;
using Task3_Drivers.Model;

namespace Task3_Drivers.Factory;

public class VehicleFactory
{
    private readonly Faker _faker;

    public void CreateSportCar(Driver driver)
    {
        var vehicle = new SportCar();
        vehicle,
    }
    public void CreateTruck(Driver driver)
    {
        var vehicle = new Truck();

        vehicle.Model = _faker.Vehicle.Model();
        vehicle.YearOfRelease = _faker.Date.Past().Year;
        vehicle.MaxSpeed = new Random().Next(100, 150);
        vehicle.HasPricep = AllowPricep(driver);
        vehicle.SetOwner(driver);
    }

    private bool AllowPricep(Driver driver)
    {
        if ((DateTime.Now.Year - driver.DateDriverLicense.Year) >= 10)
        {
            return true;
        }
        return false;
    }
}