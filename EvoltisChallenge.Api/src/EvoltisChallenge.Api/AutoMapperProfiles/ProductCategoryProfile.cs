using AutoMapper;
using EvoltisChallenge.Api.Infraestructure.dbEntities;

namespace EvoltisChallenge.Api.AutoMapperProfiles;

public class ProductCategoryProfile : Profile
{
    public ProductCategoryProfile()
    {
        _ = CreateMap<Domain.ProductCategory, ProductCategoryDb>()
            .ReverseMap();

        _ = CreateMap<Domain.ProductCategory,
            Responses.ProductCategory.ProductCategoryResponse>();
    }
}
