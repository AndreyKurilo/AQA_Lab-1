﻿namespace Task3_Drivers.Model;

public abstract class Vehicle
{
    public string Model { get; set; }
    public string Type { get; set; }
    public int YearOfRelease { get; set; }
    public Driver Owner { get; protected set; }
    public Engine Engine { get; set; }

    public abstract void SetOwner(Driver owner);
}