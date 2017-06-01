using System;
using System.Collections.Generic;
using System.Text;

namespace Merchant.Commands
{
    public class UnknownCommand : Command
    {
        public UnknownCommand(string value)
        {
            Value = value;
        }
        public string Value {get;set;}
    }
}
