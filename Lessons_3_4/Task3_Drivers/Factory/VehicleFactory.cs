using Bogus;
using Task3_Drivers.Model;
using Task3_Drivers.Model.VehicleTypes;

namespace Task3_Drivers.Factory;

public class VehicleFactory
{
    private readonly Faker _faker;

    public void CreateMinivan(Driver driver)
    {
        var vehicle = new Minivan();
        int min = 100;
        int max = 150;

        SetAttributes(driver, vehicle, min, max);
        vehicle.Seats = new Random().Next(1, 10);
    }
    
    public void CreateSportCar(Driver driver)
    {
        var vehicle = new SportCar();
        int min = 200;
        int max = 350;

        SetAttributes(driver, vehicle, min, max);
        
    }
    public void CreateTruck(Driver driver)
    {
        var vehicle = new Truck();
        int min = 100;
        int max = 150;

        SetAttributes(driver, vehicle, min, max);
        vehicle.HasPricep = AllowPricep(driver);
    }

    private void SetAttributes(Driver driver, Vehicle vehicle, int intervalMin, int intervalMax)
    {
        vehicle.Model = _faker.Vehicle.Model();
        vehicle.YearOfRelease = _faker.Date.Past().Year;
        vehicle.MaxSpeed = new Random().Next(intervalMin, intervalMax);
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