using System.Text.Json.Serialization;
using Application.DependencyResolver;
using Persistence.DependencyResolver;


var builder = WebApplication.CreateBuilder(args);

var appSettings = GetAppSettings();


RegisterMediatrServices();
RegisterServices();




// Add services to the container.

builder.Services.AddControllers();
   
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();





var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


void RegisterServices()
{
    DependencyResolverPersistence.Register(builder.Services, appSettings);
    DependencyResolverService.Register(builder.Services, appSettings);
}

void RegisterMediatrServices()
{
    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
        typeof(DependencyResolverPersistence).Assembly,
        typeof(DependencyResolverService).Assembly
    ));
        
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


await MigrateDatabase(app);


app.Run();

IConfiguration GetAppSettings()
{
    return new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
        .Build();
}



async Task MigrateDatabase(WebApplication appWeb)
{
    using var scope = appWeb.Services.CreateScope();
    await DependencyResolverPersistence.MigrateDatabase(scope.ServiceProvider);
}



