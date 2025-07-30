namespace EvoltisChallenge.Api.Requests.Product;

public record UpdateProductRequest(
    string Name,
    string Description,
    double Price,
    Guid ProductCategoryId
);
