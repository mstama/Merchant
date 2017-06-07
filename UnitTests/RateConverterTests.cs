using Merchant.Services;
using Xunit;

namespace UnitTests
{
    public class RateCalculatorTests
    {
        private const string Category = "RateCalculator";

        [Fact]
        [Trait("Category", Category)]
        public void TestRateCommand()
        {
            // Arrange
            var target = new RateCalculator();
            target.AddRate("silver", 12.5);
            // Act
            var output = target.ToCredits("silver", 2);
            // Assert
            Assert.Equal<double>(25, output);
        }
    }
}