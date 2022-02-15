using JetBrains.Annotations;
namespace Task3_Drivers.Model;

public abstract class Vehicle
{
    public string Model { get; set; } = string.Empty;
    public int YearOfRelease { get; set; }

    public Driver Owner { get; protected set; } = default!;
    public Engine Engine { get; set; } = null!;

    public int MaxSpeed { get; set; }

    public abstract Driver? SetOwner(Driver driver);

    public void PrintTechnicalDetails()
    {
        Console.WriteLine("Model: " + Model);
        Console.WriteLine("Year of production: " + YearOfRelease);
        Console.WriteLine("Engine capacity: " + Engine.Capacity);
        Console.WriteLine("Engine consumption: " + Engine.Consumption);
        Console.WriteLine("Max speed:" + MaxSpeed);
    }

    public void PrintConsumptionDetails()
    {
        Console.WriteLine(
            $"Driving experience {Owner.Name} {Owner.Surname} starts in {Owner.DateDriverLicense.Year} ");
    }

    public void PrintCalculatedTripDetails(int distanceToRide)
    {
        var litres = Math.Round(distanceToRide / 100f * Engine.Consumption, 2);
        var duration = (float) distanceToRide / MaxSpeed;
        TimeSpan durationTimeSpan = TimeSpan.FromHours(duration);
        var formattedDuration = durationTimeSpan.ToString(@"hh\h\o\u\r\ mm\m\i\n\ ss\s\e\c");
        Console.WriteLine($"This trip takes {litres} litres");
        Console.WriteLine($"Trip duration is: " + formattedDuration);
    }
}