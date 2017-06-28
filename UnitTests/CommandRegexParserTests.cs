using Merchant.Models;
using Merchant.Services;
using System;
using Xunit;

namespace UnitTests
{
    public class CommandRegexParserTests
    {
        private const string _category = "CommandRegexParser";

        private readonly CommandRegexParser _target = new CommandRegexParser();

        [Fact]
        [Trait("Category", _category)]
        public void TestManyQueryCommand()
        {
            // Arrange
            string input = "how many Credits is glob prok Iron ?";
            // Act
            var output = _target.Parse(input);
            // Assert
            Assert.IsType<ManyQueryCommand>(output);
            var final = output as ManyQueryCommand;
            Assert.Equal<string>("glob prok", final.AlienValue);
            Assert.Equal<string>("Iron", final.Commodity);
        }

        [Fact]
        [Trait("Category", _category)]
        public void TestMapCommand()
        {
            // Arrange
            string input = "glob is I";
            // Act
            var output = _target.Parse(input);
            // Assert
            Assert.IsType<MapCommand>(output);
            var final = output as MapCommand;
            Assert.Equal<string>("glob", final.From);
            Assert.Equal<string>("I", final.To);
        }

        [Fact]
        [Trait("Category", _category)]
        public void TestMuchQueryCommand()
        {
            // Arrange
            string input = "how much is pish tegj glob glob ?";
            // Act
            var output = _target.Parse(input);
            // Assert
            Assert.IsType<MuchQueryCommand>(output);
            var final = output as MuchQueryCommand;
            Assert.Equal<string>("pish tegj glob glob", final.AlienValue);
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        [Trait("Category", _category)]
        public void TestNullCommand(string input)
        {
            // Act
            var output = _target.Parse(input);
            // Assert
            Assert.IsType<NullCommand>(output);
        }

        [Fact]
        [Trait("Category", _category)]
        public void TestRateCommand()
        {
            // Arrange
            string input = "glob glob Silver is 34 Credits";
            // Act
            var output = _target.Parse(input);
            // Assert
            Assert.IsType<RateCommand>(output);
            var final = output as RateCommand;
            Assert.Equal<string>("glob glob", final.Amount);
            Assert.Equal<String>("Silver", final.Commodity);
            Assert.Equal<int>(34, final.CreditValue);
        }

        [Fact]
        [Trait("Category", _category)]
        public void TestUnknownCommand()
        {
            // Arrange
            string input = "how much wood could a woodchuck chuck if a woodchuck could chuck wood ?";
            // Act
            var output = _target.Parse(input);
            // Assert
            Assert.IsType<UnknownCommand>(output);
        }
    }
}