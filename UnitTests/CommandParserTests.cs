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
            var final = output as MapCommand;
            Assert.Equal<string>("GLOB", final.From);
            Assert.Equal<string>("I", final.To);
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
            var final = output as RateCommand;
            Assert.Equal<string>("GLOB GLOB", final.Amount);
            Assert.Equal<String>("SILVER", final.Commodity);
            Assert.Equal<int>(34, final.CreditValue);
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
            var final = output as MuchQueryCommand;
            Assert.Equal<string>("PISH TEGJ GLOB GLOB", final.Amount);
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
            var final = output as ManyQueryCommand;
            Assert.Equal<string>("GLOB PROK", final.Amount);
            Assert.Equal<string>("IRON", final.Commodity);
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
