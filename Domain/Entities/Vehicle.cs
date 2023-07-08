using Domain.Core.Models;

namespace Domain.Entities;

public class Vehicle : BaseEntity
{

    public Vehicle() { }
    public decimal Value { get; set; }
    public string  Brand { get; set;} = string.Empty;
    public string  Model { get; set;} = string.Empty;
    public int Year { get; set; }
    public VehicleType VehicleType { get; set; }

    public Insurance Insurance { get; set; }
}

public enum VehicleType
{
    Car,
    Motorcycle
}