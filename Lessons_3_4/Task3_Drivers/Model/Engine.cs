using JetBrains.Annotations;

namespace Task3_Drivers.Model;

[UsedImplicitly]
public class Engine
{
    public int Capacity { get; [UsedImplicitly] set; }

    public int Power { get; [UsedImplicitly] set; }

    public string? FuelType { get; [UsedImplicitly] set; }

    public float Consumption { get; [UsedImplicitly] set; }
}