using Xunit;

namespace EvoltisChallenge.Api.UnitTests.Repositories
{
    public class RepositoryUnitTest
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            int expected = 5;
            int actual = 2 + 3;
            // Act
            // Call the repository.
            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
