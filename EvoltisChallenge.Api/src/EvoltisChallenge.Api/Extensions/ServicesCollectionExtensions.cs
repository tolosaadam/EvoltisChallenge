using EvoltisChallenge.Api.Application;
using EvoltisChallenge.Api.AutoMapperProfiles;
using FluentValidation;
using System;

namespace EvoltisChallenge.Api.Extensions;

public static class ServicesCollectionExtensions
{
    public static IServiceCollection AddMediatRSettings(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(ApplicationAssemblyReference).Assembly);
        });

        return services;
    }

    public static IServiceCollection AddValidatorSettings(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<ApplicationAssemblyReference>();

        return services;
    }

    public static IServiceCollection AddAutoMapperSettings(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg =>
        {
            cfg.AddProfile<ProductProfile>();
            cfg.AddProfile<ProductCategoryProfile>();
        });

        return services;
    }

    public static IServiceCollection AddSwaggerSettings(this IServiceCollection services)
    {
        services.AddSwaggerGen();

        return services;
    }

    public static IServiceCollection AddCorsSettings(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAllOrigins", policy =>
            {
                policy.WithOrigins("*")
                      .AllowAnyHeader()
                      .AllowAnyMethod();
            });
        });

        return services;
    }
}
