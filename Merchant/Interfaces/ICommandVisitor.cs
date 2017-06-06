using Merchant.Commands;

namespace Merchant.Interfaces
{
    /// <summary>
    /// Interface for the visitor patter on command
    /// </summary>
    public interface ICommandVisitor
    {
        void Visit(ManyQueryCommand command);

        void Visit(MapCommand command);

        void Visit(MuchQueryCommand command);

        void Visit(RateCommand command);

        void Visit(UnknownCommand command);
    }
}