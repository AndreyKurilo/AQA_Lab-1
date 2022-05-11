using Bogus;
using Task3_Drivers.Model;
using Task3_Drivers.Model.VehicleTypes;

namespace Task3_Drivers.Factory;

public class VehicleFactory
{
    private readonly Faker _faker;

    public VehicleFactory()
    {
        _faker = new Faker();
    }

    public Vehicle CreateMinivan()
    {
        var vehicle = new Minivan();
        const int minBoundMaxSpeed = 100;
        const int maxBoundMaxSpeed = 150;

        SetAttributes(vehicle, minBoundMaxSpeed, maxBoundMaxSpeed);
        vehicle.Seats = new Random().Next(1, 10);

        return vehicle;
    }
    
    public Vehicle CreateSportCar()
    {
        var vehicle = new SportCar();
        const int minBoundMaxSpeed = 200;
        const int maxBoundMaxSpeed = 350;

        SetAttributes(vehicle, minBoundMaxSpeed, maxBoundMaxSpeed);

        return vehicle;
    }
    public Vehicle CreateTruck(bool hasPricep = false)
    {
        var vehicle = new Truck();
        const int minBoundMaxSpeed = 100;
        const int maxBoundMaxSpeed = 150;

        SetAttributes(vehicle, minBoundMaxSpeed, maxBoundMaxSpeed);
        vehicle.HasPricep = hasPricep;

        return vehicle;
    }

    private void SetAttributes(Vehicle vehicle, int minBoundMaxSpeed, int maxBoundMaxSpeed)
    {
        vehicle.Model = _faker.Vehicle.Model();
        vehicle.Engine = new Faker<Engine>()
            .RuleFor(x => x.Capacity, faker => faker.Random.Number(1000, 10000))
            .RuleFor(x => x.Power, faker => faker.Random.Number(100, 500))
            .RuleFor(x => x.FuelType, faker => faker.Vehicle.Fuel())
            .RuleFor(x => x.Consumption, faker => faker.Random.Number(10, 20))
            .Generate();
        vehicle.YearOfRelease = _faker.Date.Past().Year;
        vehicle.MaxSpeed = new Random().Next(minBoundMaxSpeed, maxBoundMaxSpeed);
    }
}