using EvoltisChallenge.Api.Application.Interfaces.Persistence;
using EvoltisChallenge.Api.Application.Queries.Product.GetById;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoltisChallenge.Api.UnitTests.Application.Queries.Product.GetById;

public class GetByIdProductQueryHandlerTests
{
    private readonly Mock<IEfProductRepository> _pRepositoryMock = new();
    private GetByIdProductQueryHandler _handler = null!;
    private static readonly Guid GuidMock = Guid.Parse("d2719b70-bb2b-4c58-8f22-6ecb7db8a9a9");

    public GetByIdProductQueryHandlerTests()
    {
        _handler = new GetByIdProductQueryHandler(
            _pRepositoryMock.Object
        );
    }

    [Fact]
    public async Task Handle_ShouldGetByIdProduct()
    {
        // Arrange
        var command = new GetByIdProductQuery(GuidMock);

        var cancellationToken = CancellationToken.None;

        var product = new Domain.Product
        {
            Name = "Product 1",
            Description = "",
            Price = 1,
            ProductCategoryId = GuidMock,
        };

        _pRepositoryMock
            .Setup(r => r.GetByIdAsync(command.Id, cancellationToken))
            .ReturnsAsync(product);

        // Act
        await _handler.Handle(command, cancellationToken)!;

        // Assert
        _pRepositoryMock.Verify(
            u => u.GetByIdAsync(command.Id, cancellationToken),
            Times.Once
        );
    }
}
