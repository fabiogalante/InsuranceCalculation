using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data;

public class InsuranceContext : DbContext
{


    public InsuranceContext()
    {
        

    }
    public InsuranceContext(DbContextOptions<InsuranceContext> options) : base(options) { }

    public DbSet<Insured> Insureds { get; set; }

    public DbSet<Vehicle> Vehicles { get; set; }

    public DbSet<Insurance> Insurances { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Insurance>()
            .HasIndex(e => e.InsuredId)
            .IsUnique(false);

        modelBuilder.Entity<Insurance>()
            .HasIndex(e => e.VehicleId)
            .IsUnique(false);


        modelBuilder.Entity<Insurance>()
            .HasOne(i => i.Vehicle)
            .WithOne(v => v.Insurance)
            .HasForeignKey<Insurance>(i => i.VehicleId);


        modelBuilder.Entity<Insurance>()
            .HasOne(i => i.Insured)
            .WithOne(ins => ins.Insurance)
            .HasForeignKey<Insurance>(i => i.InsuredId);


        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(InsuranceContext).Assembly);
    }

}
