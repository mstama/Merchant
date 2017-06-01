using System;
using System.Collections.Generic;
using System.Text;

namespace Merchant.Commands
{
    public class ManyQueryCommand
    {
        public ManyQueryCommand(string commodity, string amount)
        {
            Commodity = commodity;
            Amount = amount;
        }
        public string Amount { get; set; }
        public string Commodity { get; set; }
    }
}
