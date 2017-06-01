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
    }
}
