using Merchant.Models;
using Merchant.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests
{
    public class CommandVisitorTests
    {
        private const string Category = "CommandVisitor";

        private readonly CommandVisitor _target = new CommandVisitor(null, null, null);

        [Fact]
        [Trait("Category", Category)]
        public void TestManyQueryCommand()
        {
            //Arrange
            var command = new UnknownCommand("test");

            // Act
            command.Accept(_target);
        }
    }
}