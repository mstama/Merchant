using Merchant.Converters;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests
{
    public class RateConverterTests
    {
        [Fact]
        public void TestRateCommand()
        {
            // Arrange
            var target = new RateConverter();
            target.AddRate("silver", 12.5);
            // Act
            var output = target.ToCredits("silver", 2);
            // Assert
            Assert.Equal<double>(25, output);
        }
    }
}
