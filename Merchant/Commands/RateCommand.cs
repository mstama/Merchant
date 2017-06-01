using System;
using System.Collections.Generic;
using System.Text;

namespace Merchant.Commands
{
    public class RateCommand : Command
    {
        public RateCommand(string commodity, string amount, int creditValue)
        {
            Commodity = commodity;
            Amount = amount;
            CreditValue = creditValue;
        }
        public int CreditValue { get; set; }
        public string Commodity { get; set; }
        public string Amount { get; set; }
        public override string ToString()
        {
            return string.Format("{0} {1} is {2} Credits", Amount, Commodity, CreditValue);
        }
    }
}
