using Merchant;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests
{
    public class RateCalculatorTests
    {
        [Fact]
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
