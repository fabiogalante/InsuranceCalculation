using Application.Insurances;
using Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DependencyResolver;

public static class DependencyResolverService
{
    public static void Register(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IInsuranceData, InsuranceData>();
    }
}