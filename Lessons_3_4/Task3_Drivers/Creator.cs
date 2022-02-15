using Task3_Drivers.Factory;
using Task3_Drivers.Model;

namespace Task3_Drivers;

public class Creator
{
    private readonly VehicleFactory _vehicleFactory;
    private readonly DriverFactory _driverFactory;

    public Creator(VehicleFactory vehicleFactory, DriverFactory driverFactory)
    {
        _vehicleFactory = vehicleFactory;
        _driverFactory = driverFactory;
    }

    public List<Driver> CreateDrivers(int driversCount)
    {
        var drivers = new List<Driver>();

        for (int i = 0; i < driversCount; i++)
        {
            drivers.Add(_driverFactory.Create());
        }

        return drivers;
    }

    public List<Vehicle> CreateVehiclesFor(List<Driver> drivers)
    {
        var vehicles = new List<Vehicle>();

        FillWithRandomVehicles(drivers.Count, vehicles);

        for (var i = 0; i < vehicles.Count; i++)
        {
            Vehicle vehicle = vehicles[i];
            Driver driver = drivers[i];

            vehicle.SetOwner(driver);
            driver.Vehicle = vehicle;
        }

        return vehicles;
    }

    private void FillWithRandomVehicles(int count, List<Vehicle> vehicles)
    {
        for (int i = 0; i < count; i++)
        {
            switch (Randomizer.GetRandomNumberBetween(0, 3))
            {
                case 0:
                    vehicles.Add(GetRandomVehicle());
                    break;
                case 1:
                    vehicles.Add(GetRandomVehicle());
                    break;
                case 2:
                    vehicles.Add(GetRandomVehicle());
                    break;
            }
        }
    }

    private Vehicle GetRandomVehicle() =>
        Randomizer.GetRandomNumberBetween(0, 3) switch
        {
            0 => _vehicleFactory.CreateSportCar(),
            1 => _vehicleFactory.CreateMinivan(),
            _ => _vehicleFactory.CreateTruck()
        };
}