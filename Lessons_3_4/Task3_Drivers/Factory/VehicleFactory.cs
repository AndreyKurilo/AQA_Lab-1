using Bogus;

namespace Task3_Drivers;

public class VehicleFactory
{
    public void Create()
    {
        var vehicle = new Vehicle();
        var faker = new Faker();

        vehicle.Model = faker.Vehicle.Model();
        vehicle.Type = faker.Vehicle.Type();
        vehicle.YearOfRelease = faker.Date.Past().Year;
        vehicle.Owner = 
    }
}