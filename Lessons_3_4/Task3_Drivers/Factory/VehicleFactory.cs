using Bogus;
using Task3_Drivers.Model;

namespace Task3_Drivers.Factory;

public class VehicleFactory
{
    public void CreateTruck()
    {
        var vehicle = new Truck();
        var faker = new Faker();

        vehicle.Model = faker.Vehicle.Model();
        vehicle.Type = faker.Vehicle.Type();
        vehicle.YearOfRelease = faker.Date.Past().Year;
        vehicle.SetOwner(null);
    }
}