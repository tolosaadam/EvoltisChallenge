using EvoltisChallenge.Api.Application.Interfaces.Persistence;
using EvoltisChallenge.Api.Application.Queries.Product.GetAll;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoltisChallenge.Api.UnitTests.Application.Queries.Product.GetAll;

public class GetAllProductQueryHandlerTests
{
    private readonly Mock<IEfProductRepository> _productRepositoryMock = new();

    private GetAllProductQueryHandler _handler = null!;

    public GetAllProductQueryHandlerTests()
    {
        _handler = new GetAllProductQueryHandler(
            _productRepositoryMock.Object
        );
    }

    [Fact]
    public async Task Handle_ShouldReturnProducts()
    {
        // Arrange
        var cancellationToken = CancellationToken.None;

        IEnumerable<Domain.Product> products =
        [
            new Domain.Product
            {
                Id = Guid.Parse("42345678-1234-1234-1234-1234567890ab"),
                Name = "Keyboard",
                Description = "Logitech white",
                CreatedAt = new DateTime(2025, 6, 10),
                ModifiedAt = new DateTime(2025, 6, 10)
            },
            new Domain.Product
            {
                Id = Guid.Parse("52345678-1234-1234-1234-1234567890ab"),
                Name = "Mouse",
                Description = "Logitech black",
                CreatedAt = new DateTime(2025, 6, 10),
                ModifiedAt = new DateTime(2025, 6, 10)
            },
            new Domain.Product
            {
                Id = Guid.Parse("62345678-1234-1234-1234-1234567890ab"),
                Name = "Shirt",
                Description = "Green XXL",
                CreatedAt = new DateTime(2025, 6, 10),
                ModifiedAt = new DateTime(2025, 6, 10)
            },
            new Domain.Product
            {
                Id = Guid.Parse("72345678-1234-1234-1234-1234567890ab"),
                Name = "Cap",
                Description = "New School",
                CreatedAt = new DateTime(2025, 6, 10),
                ModifiedAt = new DateTime(2025, 6, 10)
            }
        ];

        _productRepositoryMock
                .Setup(r => r.GetAllIncludeAsync(cancellationToken))
                .ReturnsAsync(products);

        var query = new GetAllProductQuery();

        // Act
        var result = await _handler.Handle(query, cancellationToken)!;

        // Assert
        Assert.NotNull(result);
        Assert.IsAssignableFrom<IEnumerable<Domain.Product>>(result);

        var resultList = result.ToList();
        Assert.Equal(4, resultList.Count);

        // Validar que contenga los 4 productos esperados
        Assert.Contains(resultList, p => p.Id == Guid.Parse("42345678-1234-1234-1234-1234567890ab") && p.Name == "Keyboard" && p.Description == "Logitech white");
    }
}
