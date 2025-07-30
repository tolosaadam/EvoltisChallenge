using AutoMapper;
using EvoltisChallenge.Api.Infraestructure.dbEntities;

namespace EvoltisChallenge.Api.AutoMapperProfiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        #region Create

        _ = CreateMap<Requests.Product.CreateProductRequest,
            Application.Commands.Product.Create.CreateProductCommand>()
            .ConstructUsing(src =>
            new Application.Commands.Product.Create.CreateProductCommand(
                src.Name,
                src.Description,
                src.Price,
                src.ProductCategoryId));

        _ = CreateMap<Application.Commands.Product.Create.CreateProductCommand,
            Domain.Product>()
            .ForMember(dest => dest.Category, opt => opt.Ignore());

        #endregion

        #region Update

        _ = CreateMap<(Requests.Product.UpdateProductRequest request, Guid id),
            Application.Commands.Product.Update.UpdateProductCommand>()
            .ConstructUsing(src =>
            new Application.Commands.Product.Update.UpdateProductCommand(
                src.id,
                src.request.Name,
                src.request.Description,
                src.request.Price,
                src.request.ProductCategoryId));

        _ = CreateMap<Application.Commands.Product.Update.UpdateProductCommand,
            Domain.Product>()
            .ForMember(dest => dest.Category, opt => opt.Ignore());

        #endregion


        #region Repository

        _ = CreateMap<Domain.Product,
            ProductDb > ()
            .ForMember(dest => dest.Category, opt => opt.Ignore());

        _ = CreateMap<ProductDb,
           Domain.Product>();

        #endregion

        #region Responses

        _ = CreateMap<Domain.Product,
            Responses.Product.ProductResponse>();

        #endregion
    }
}
