namespace EvoltisChallenge.Api.Requests.Product;

public record CreateProductRequest(
    string Name,
    string Description,
    double Price,
    Guid ProductCategoryId
);
