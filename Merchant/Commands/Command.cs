using Merchant.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merchant.Commands
{
    public abstract class Command
    {
        public abstract void Accept(IVisitor visitor);
    }
}
