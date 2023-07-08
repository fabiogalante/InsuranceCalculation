using Application.DependencyResolver;
using Application.Insurances;
using InsuranceWeb.Pages;
using Microsoft.AspNetCore.Hosting;
using Persistence.DependencyResolver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(ArithmeticAverages.Query).Assembly));

builder.Services.AddHttpClient();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();


app.Run();
