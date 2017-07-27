// Copyright (c) 2017 Marcos Tamashiro. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Merchant.Models;
using Merchant.Services;
using Xunit;

namespace UnitTests
{
    public class CommandVisitorTests
    {
        private const string _category = "CommandVisitor";

        private readonly CommandVisitor _target = new CommandVisitor(null, null, null);

        [Fact]
        [Trait("Category", _category)]
        public void TestManyQueryCommand()
        {
            //Arrange
            var command = new UnknownCommand("test");

            // Act
            command.Accept(_target);
        }
    }
}