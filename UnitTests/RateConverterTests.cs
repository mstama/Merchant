// Copyright (c) 2017 Marcos Tamashiro. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Merchant.Services;
using Xunit;

namespace UnitTests
{
    public class RateCalculatorTests
    {
        private const string _category = "RateCalculator";

        [Fact]
        [Trait("Category", _category)]
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