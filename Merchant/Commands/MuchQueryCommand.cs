using Merchant.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merchant.Commands
{
    public class MuchQueryCommand:Command
    {
        public MuchQueryCommand(string amount)
        {
            Amount = amount;
        }
        public string Amount { get; set; }

        public override string ToString()
        {
            return string.Format("How much is {0}?" ,Amount);
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
