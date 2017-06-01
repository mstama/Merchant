using Merchant;
using Merchant.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests
{
    public class CommandParserTests
    {
        [Fact]
        public void TestMapCommand()
        {
            // Arrange
            string input = "glob is I";
            // Act
            var output = CommandParser.Parse(input);
            // Assert
            Assert.IsType<MapCommand>(output);
        }

        [Fact]
        public void TestRateCommand()
        {
            // Arrange
            string input = "glob glob Silver is 34 Credits";
            // Act
            var output = CommandParser.Parse(input);
            // Assert
            Assert.IsType<RateCommand>(output);
        }

        [Fact]
        public void TestMuchQueryCommand()
        {
            // Arrange
            string input = "how much is pish tegj glob glob ?";
            // Act
            var output = CommandParser.Parse(input);
            // Assert
            Assert.IsType<MuchQueryCommand>(output);
        }

        [Fact]
        public void TestManyQueryCommand()
        {
            // Arrange
            string input = "how many Credits is glob prok Iron ?";
            // Act
            var output = CommandParser.Parse(input);
            // Assert
            Assert.IsType<ManyQueryCommand>(output);
        }

        [Fact]
        public void TestUnknownCommand()
        {
            // Arrange
            string input = "how much wood could a woodchuck chuck if a woodchuck could chuck wood ?";
            // Act
            var output = CommandParser.Parse(input);
            // Assert
            Assert.IsType<UnknownCommand>(output);
        }
    }
}
