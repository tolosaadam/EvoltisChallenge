using EvoltisChallenge.Api.Responses.ProductCategory;

namespace EvoltisChallenge.Api.Responses.Product;

public record ProductResponse(
    Guid Id,
    string Name,
    string Description,
    double Price,
    Guid ProductCategoryId
);
