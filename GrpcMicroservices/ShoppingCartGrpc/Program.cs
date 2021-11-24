using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShoppingCartGrpc.Data;
using ShoppingCartGrpc.Services;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
var services = builder.Services;

services.AddGrpc(options =>
{
    options.EnableDetailedErrors = true;
});

services.AddDbContext<ShoppingCartContext>(options =>
    options.UseInMemoryDatabase("Products"));

services.AddAutoMapper(typeof(Program));

var app = builder.Build();
using var scope = app.Services.CreateScope();
var productContext = scope.ServiceProvider.GetService<ShoppingCartContext>();
ShoppingCartContextSeed.SeedAsync(productContext);

// Configure the HTTP request pipeline.
app.MapGrpcService<ShoppingCartService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
