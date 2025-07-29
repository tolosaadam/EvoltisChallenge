using EvoltisChallenge.Api.EndpointsDefinitions.Product;
using EvoltisChallenge.Api.EndpointsDefinitions.ProductType;
using EvoltisChallenge.Api.Extensions;
using EvoltisChallenge.Api.Infraestructure.Repositories.Ef;
using EvoltisChallenge.Api.Middlewares;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

Console.WriteLine($"Ambiente actual: {builder.Environment.EnvironmentName}");

builder.Services.AddEndpointsApiExplorer();

builder.Services
    .AddMediatRSettings()
    .AddAutoMapperSettings()
    .AddValidatorSettings()
    .AddInfraestructureSettings(builder.Configuration)
    .AddSwaggerSettings()
    .AddBehaviorSettings()
    .AddCorsSettings();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
db.Database.Migrate();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllOrigins")
    .UseHttpsRedirection()
    .UseMiddleware<HandlingExceptionMiddleware>();

app.MapProductEndpoints()
    .MapProductCategoryEndpoints()
    .Run();

