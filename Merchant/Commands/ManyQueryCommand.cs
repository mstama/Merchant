﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Merchant.Commands
{
    public class ManyQueryCommand : Command
    {
        public ManyQueryCommand(string commodity, string amount)
        {
            Commodity = commodity;
            Amount = amount;
        }
        public string Amount { get; set; }
        public string Commodity { get; set; }
        public override string ToString()
        {
            return string.Format("How many Credits is {0} {1}", Amount, Commodity);
        }
    }
}
