using Domain.Entities;
using InsuredMemberData;

namespace Persistence.Data;

public class Seed
{
    public static async Task SeedData(InsuranceContext context)
    {
        if (context.Vehicles.Any() && context.Insureds.Any()) return;

        var vehicles = new List<Vehicle>
        {
            new Vehicle { Brand = "BMW", Model = "X5", Year = 2019, Value = 100000, VehicleType = VehicleType.Car},
            new Vehicle { Brand = "BMW", Model = "X6", Year = 2020, Value = 120000, VehicleType = VehicleType.Car},
            new Vehicle { Brand = "BMW", Model = "X7", Year = 2021, Value = 140000, VehicleType = VehicleType.Car},
            new Vehicle { Brand = "Audi", Model = "A3", Year = 2019, Value = 80000, VehicleType = VehicleType.Car},
            new Vehicle { Brand = "Audi", Model = "A4", Year = 2020, Value = 90000, VehicleType = VehicleType.Car},
            new Vehicle { Brand = "Mercedes", Model = "C", Year = 2019, Value = 80000, VehicleType = VehicleType.Car},
            new Vehicle { Brand = "BMW", Model = "R 1250 GS", Year = 2021, Value = 20000, VehicleType = VehicleType.Motorcycle},
            new Vehicle { Brand = "Honda", Model = "CB 500", Year = 2021, Value = 10000, VehicleType = VehicleType.Motorcycle},
            new Vehicle { Brand = "Yamaha", Model = "MT-07", Year = 2021, Value = 15000, VehicleType = VehicleType.Motorcycle},
            new Vehicle { Brand = "Suzuki", Model = "GSX-R 1000", Year = 2021, Value = 20000, VehicleType = VehicleType.Motorcycle},
            new Vehicle { Brand = "Kawasaki", Model = "Ninja 1000", Year = 2021, Value = 20000, VehicleType = VehicleType.Motorcycle},
            new Vehicle { Brand = "Kawasaki", Model = "Ninja 650", Year = 2021, Value = 15000, VehicleType = VehicleType.Motorcycle},
            new Vehicle { Brand = "Kawasaki", Model = "Ninja 400", Year = 2021, Value = 10000, VehicleType = VehicleType.Motorcycle},
            new Vehicle { Brand = "Kawasaki", Model = "Ninja 300", Year = 2021, Value = 8000, VehicleType = VehicleType.Motorcycle},
            new Vehicle { Brand = "Kawasaki", Model = "Ninja 250", Year = 2021, Value = 6000, VehicleType = VehicleType.Motorcycle},
            new Vehicle { Brand = "Kawasaki", Model = "Ninja 125", Year = 2021, Value = 4000, VehicleType = VehicleType.Motorcycle},
            new Vehicle { Brand = "Kawasaki", Model = "Z 1000", Year = 2021, Value = 20000, VehicleType = VehicleType.Motorcycle},
            new Vehicle { Brand = "Kawasaki", Model = "Z 900", Year = 2021, Value = 15000, VehicleType = VehicleType.Motorcycle}

        };

       

        var insureds = new List<Insured>();
        var insuredsFake = new InsuredsFake();

        for (var i = 0; i < 25; i++) insureds.Add(insuredsFake.GetInsured());





        await context.Vehicles.AddRangeAsync(vehicles);
        await context.Insureds.AddRangeAsync(insureds);
        await context.SaveChangesAsync();
    }
}


