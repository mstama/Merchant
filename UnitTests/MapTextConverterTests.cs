﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Merchant;
using Merchant.Converters;

namespace UnitTests
{
    public class MapTextConverterTests
    {
        [Fact]
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

        [Fact]
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
    }
}