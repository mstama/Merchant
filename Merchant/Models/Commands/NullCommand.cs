using System;
using System.Collections.Generic;
using System.Text;
using Merchant.Interfaces;

namespace Merchant.Models
{
    /// <summary>
    /// Null command
    /// </summary>
    public class NullCommand : Command
    {
        public override void Accept(ICommandVisitor visitor)
        {
            return;
        }
    }
}
