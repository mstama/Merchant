// Copyright (c) 2017 Marcos Tamashiro. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Merchant.Services;
using Xunit;

namespace UnitTests
{
    public class MapTextConverterTests
    {
        private const string _category = "MapTextConverter";

        [Fact]
        [Trait("Category", _category)]
        public void TestMap()
        {
            // Arrange
            var target = new MapTextConverter();
            target.AddMap("ping", "M");
            target.AddMap("pong", "C");
            target.AddMap("abra", "L");
            target.AddMap("cadabra", "X");
            target.AddMap("sin", "I");
            target.AddMap("sala", "V");
            var input = "ping pong ping abra cadabra cadabra cadabra sin sala";
            // Act
            var output = target.Convert(input);
            // Assert
            Assert.Equal<string>("MCMLXXXIV", output);
        }

        [Fact]
        [Trait("Category", _category)]
        public void TestNoMap()
        {
            // Arrange
            var target = new MapTextConverter();
            var input = "M C M L X X X I V";
            // Act
            var output = target.Convert(input);
            // Assert
            Assert.Equal<string>("MCMLXXXIV", output);
        }
    }
}