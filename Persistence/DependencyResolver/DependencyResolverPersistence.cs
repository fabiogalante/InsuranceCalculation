using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Data;

namespace Persistence.DependencyResolver;

public class DependencyResolverPersistence
{

    public static void Register(IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<InsuranceContext>(opt => opt.UseSqlite(config
            .GetConnectionString("DefaultConnection"), m => m.MigrationsAssembly("DbMigrations")));
    }



    public static async Task  MigrateDatabase(IServiceProvider serviceProvider)
    {
        var context = serviceProvider.GetRequiredService<InsuranceContext>();
        await context.Database.MigrateAsync();
        await Seed.SeedData(context);
    }
}