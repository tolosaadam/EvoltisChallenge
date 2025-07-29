using EvoltisChallenge.Api.Application.Queries.Product.GetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoltisChallenge.Api.UnitTests.Application.Queries.Product.GetById;

public class GetByIdProductQueryValidatorTests
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

        var validator = new GetByIdProductQueryValidator();
        var request = new GetByIdProductQuery(id);

        // Act
        var result = await validator.ValidateAsync(request);

        // Assert
        Assert.Equal(isValid, result.IsValid);
    }
}
