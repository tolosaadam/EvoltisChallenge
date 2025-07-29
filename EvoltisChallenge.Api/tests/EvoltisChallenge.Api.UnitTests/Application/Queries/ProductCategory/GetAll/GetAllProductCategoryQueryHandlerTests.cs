using EvoltisChallenge.Api.Application.Interfaces.Persistence;
using EvoltisChallenge.Api.Application.Queries.ProductCategory.GetAll;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoltisChallenge.Api.UnitTests.Application.Queries.ProductCategory.GetAll;

public class GetAllProductCategoryQueryHandlerTests
{
    private readonly Mock<IEfProductCategoryRepository> _pCategoryRepositoryMock = new();

    private GetAllProductCategoryQueryHandler _handler = null!;

    public GetAllProductCategoryQueryHandlerTests()
    {
        _handler = new GetAllProductCategoryQueryHandler(
            _pCategoryRepositoryMock.Object
        );
    }

    [Fact]
    public async Task Handle_ShouldReturnProductCategories()
    {
        // Arrange
        var cancellationToken = CancellationToken.None;

        IEnumerable<Domain.ProductCategory> productCategories =
        [
            new Domain.ProductCategory { Id = Guid.Parse("12345678-1234-1234-1234-1234567890ab"), Name = "Peripherals", Description = "PC peripherals" },
            new Domain.ProductCategory { Id = Guid.Parse("22345678-1234-1234-1234-1234567890ab"), Name = "Clothes", Description = "Wide clothes" },
            new Domain.ProductCategory { Id = Guid.Parse("32345678-1234-1234-1234-1234567890ab"), Name = "Hardware", Description = "PC hardware" }
        ];

        _pCategoryRepositoryMock
                .Setup(r => r.GetAllAsync(cancellationToken))
                .ReturnsAsync(productCategories);

        var query = new GetAllProductCategoryQuery();

        // Act
        var result = await _handler.Handle(query, cancellationToken)!;

        // Assert
        Assert.NotNull(result);
        Assert.IsAssignableFrom<IEnumerable<Domain.ProductCategory>>(result);

        var resultList = result.ToList();
        Assert.Equal(3, resultList.Count);

        Assert.Contains(resultList, p => p.Id == Guid.Parse("12345678-1234-1234-1234-1234567890ab"));
    }
}
