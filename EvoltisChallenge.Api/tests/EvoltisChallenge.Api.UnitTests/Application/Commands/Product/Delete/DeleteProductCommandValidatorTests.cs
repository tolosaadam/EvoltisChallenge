using EvoltisChallenge.Api.Application.Commands.Product.Delete;
using EvoltisChallenge.Api.Application.Commands.Product.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoltisChallenge.Api.UnitTests.Application.Commands.Product.Delete;

public class DeleteProductCommandValidatorTests
{
    [Theory]
    [InlineData("d2719b70-bb2b-4c58-8f22-6ecb7db8a9a9", true)]
    [InlineData("", false)]
    public async Task ValidatorTest(string idString, bool isValid)
    {
        // Arrange
        var id = string.IsNullOrWhiteSpace(idString)
            ? Guid.Empty
            : Guid.Parse(idString);

        var validator = new DeleteProductCommandValidator();
        var request = new DeleteProductCommand(id);

        // Act
        var result = await validator.ValidateAsync(request);

        // Assert
        Assert.Equal(isValid, result.IsValid);
    }
}
