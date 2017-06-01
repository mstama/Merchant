using Merchant.Commands;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Merchant
{
    public static class CommandParser
    {
        private static char[] _separator = new char[] { ' ' };

        public static Command Parse(string value)
        {
            value = value.ToUpperInvariant();
            var words = value.Split(_separator, StringSplitOptions.RemoveEmptyEntries);
            //It is a query
            if (value.Contains("?"))
            {
                if(value.Contains("HOW MUCH IS "))
                {
                    string amount = string.Join(" ", words.Skip(3).Take(words.Length - 5));
                    return new MuchQueryCommand(amount);
                }
                if(value.Contains("HOW MANY CREDITS IS ")) {
                    string commodity = words[words.Length - 2];
                    string amount = string.Join(" ", words.Skip(4).Take(words.Length - 6));
                }
            }
            else //Its a Mapping-Rate
            {
                // Rate
                if (value.Contains("CREDITS")){
                    int credit = int.Parse(words[words.Length - 2]);
                    string commodity = words[words.Length - 4];
                    string amount = string.Join(" ",words.Take(words.Length - 5));
                    return new RateCommand(commodity, amount, credit);
                }
                else
                {
                    return new MapCommand(words[0], words[2]);
                }
            }
            return new UnknownCommand();
        }
    }
}
