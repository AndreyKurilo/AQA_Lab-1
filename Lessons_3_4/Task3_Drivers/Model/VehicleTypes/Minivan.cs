﻿namespace Task3_Drivers.Model;

public class Minivan : Vehicle
{
    public int Seats { get; set; }
    public override Driver SetOwner(Driver driver)
    {
        return driver;
    }
}