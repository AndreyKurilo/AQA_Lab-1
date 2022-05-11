using Task3_Drivers.Factory;
using Task3_Drivers.Model;

namespace Task3_Drivers;

public static class Program
{
    public static void Main(string[] args)
    {
        var driverFactory = new DriverFactory();
        var vehicleFactory = new VehicleFactory();
        var creator = new Creator(vehicleFactory, driverFactory);
        var menu = new Menu();

        var drivers = creator.CreateDrivers(menu.AskDriversCountToCreate());
        creator.CreateVehiclesFor(drivers);

        menu.PrintDrivers(drivers);
        
        Driver pickedDriver = menu.PickDriver(drivers);
        VehicleDetailsType pickedVehicleDetailsTypeType = menu.PickVehicleInformationType();
        Vehicle? driverVehicle = pickedDriver.Vehicle;

        switch (pickedVehicleDetailsTypeType)
        {
            case VehicleDetailsType.TechnicalDetails:
                driverVehicle.PrintTechnicalDetails();
                break;
            case VehicleDetailsType.ConsumptionDetails:
                var distance = menu.AskForDistance();
                driverVehicle.PrintConsumptionDetails();
                driverVehicle.PrintCalculatedTripDetails(distance);
                break;
        }
    }
}