namespace EvoltisChallenge.Api.EndpointsDefinitions.Product;

public static class EndPointDefinition
{
    public static WebApplication MapProductEndpoints(this WebApplication app)
    {
        app.MapGet("/products", Endpoints.GetAll)
            .Produces<IEnumerable<Responses.Product.ProductResponse>>(StatusCodes.Status200OK)
            .ProducesValidationProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithName("Get all products")
            .WithTags("Product-Queries")
            .AllowAnonymous()
            .WithOpenApi();

        app.MapGet("/products/{id}", Endpoints.GetById)
            .Produces<Responses.Product.ProductResponse>(StatusCodes.Status200OK)
            .ProducesValidationProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithName("Get product")
            .WithTags("Product-Queries")
            .AllowAnonymous()
            .WithOpenApi();

        app.MapPost("/products", Endpoints.Create)
            .Produces<Guid>(StatusCodes.Status201Created)
            .ProducesValidationProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithName("Create product")
            .WithTags("Product-Commands")
            .AllowAnonymous()
            .WithOpenApi();

        app.MapPut("/products/{id}", Endpoints.Update)
            .Produces(StatusCodes.Status204NoContent)
            .ProducesValidationProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithName("Update product")
            .WithTags("Permission-Commands")
            .AllowAnonymous()
            .WithOpenApi();

        app.MapDelete("/products/{id}", Endpoints.Delete)
            .Produces(StatusCodes.Status204NoContent)
            .ProducesValidationProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithName("Delete product")
            .WithTags("Product-Commands")
            .AllowAnonymous()
            .WithOpenApi();

        return app;
    }

    public static IServiceCollection AddProductServices(this IServiceCollection services, IConfiguration configuration)
    {

        return services;
    }
}
