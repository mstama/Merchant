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