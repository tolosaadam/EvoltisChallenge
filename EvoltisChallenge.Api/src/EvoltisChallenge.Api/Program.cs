using EvoltisChallenge.Api.Extensions;
using EvoltisChallenge.Api.Infraestructure.Repositories.Ef;
using EvoltisChallenge.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

Console.WriteLine($"Ambiente actual: {builder.Environment.EnvironmentName}");

builder.Services.AddEndpointsApiExplorer();

builder.Services
    .AddMediatRSettings()
    .AddAutoMapperSettings()
    .AddValidatorSettings()
    .AddInfraestructureSettings(builder.Configuration)
    .AddSwaggerSettings()
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

app.Run();

