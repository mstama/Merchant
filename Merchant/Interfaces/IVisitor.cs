using Merchant.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merchant.Interfaces
{
    public interface IVisitor
    {
        void Visit(ManyQueryCommand command);

        void Visit(MapCommand command);

        void Visit(MuchQueryCommand command);

        void Visit(RateCommand command);

        void Visit(UnknownCommand command);
    }
}
