using Merchant.Interfaces;

namespace Merchant.Models
{
    /// <summary>
    /// Null command
    /// </summary>
    public class NullCommand : Command
    {
        /// <summary>
        /// Do nothing with the visitor
        /// </summary>
        /// <param name="visitor"></param>
        public override void Accept(ICommandVisitor visitor)
        { }
    }
}