using Merchant.Models;

namespace Merchant.Interfaces
{
    /// <summary>
    /// Interface for the visitor pattern on command
    /// </summary>
    public interface ICommandVisitor
    {
        /// <summary>
        /// Visit the ManyQueryCommand
        /// </summary>
        /// <param name="command"></param>
        void Visit(ManyQueryCommand command);

        /// <summary>
        /// Visit the MapCommand
        /// </summary>
        /// <param name="command"></param>
        void Visit(MapCommand command);

        /// <summary>
        /// Visit the MuchQueryCommand
        /// </summary>
        /// <param name="command"></param>
        void Visit(MuchQueryCommand command);

        /// <summary>
        /// Visit the RateCommand
        /// </summary>
        /// <param name="command"></param>
        void Visit(RateCommand command);

        /// <summary>
        /// Visit the UnknownCommand
        /// </summary>
        /// <param name="command"></param>
        void Visit(UnknownCommand command);
    }
}