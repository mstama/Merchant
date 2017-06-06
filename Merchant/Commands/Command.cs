using Merchant.Interfaces;

namespace Merchant.Commands
{
    /// <summary>
    /// Base class for commands
    /// </summary>
    public abstract class Command
    {
        /// <summary>
        /// Visit operation
        /// </summary>
        /// <param name="visitor"></param>
        public abstract void Accept(ICommandVisitor visitor);
    }
}