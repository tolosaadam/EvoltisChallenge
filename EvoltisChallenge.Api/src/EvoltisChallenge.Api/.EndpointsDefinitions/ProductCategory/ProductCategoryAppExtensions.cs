namespace EvoltisChallenge.Api.EndpointsDefinitions.ProductType;

public static class EndPointDefinition
{
    public static WebApplication MapProductCategoryEndpoints(this WebApplication app)
    {
        app.MapGet("/product-categories", Endpoints.GetAll)
            .Produces<IEnumerable<Responses.ProductCategory.ProductCategoryResponse>>(StatusCodes.Status200OK)
            .ProducesValidationProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithName("Get all product categories")
            .WithTags("ProductCategory-Queries")
            .AllowAnonymous()
            .WithOpenApi();

        return app;
    }

    public static IServiceCollection AddProductCategoryServices(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}
