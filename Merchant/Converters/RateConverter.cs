using System;
using System.Collections.Generic;
using System.Text;

namespace Merchant.Converters
{
    public class RateConverter
    {
        private Dictionary<string, double> _dict = new Dictionary<string, double>();

        public double ToCredits(string commodity, int amount)
        {
            double rate = _dict[commodity];
            return amount * rate;
        } 

        public void AddRate(string commodity, double rate)
        {
            _dict.Add(commodity, rate);
        }
    }
}
