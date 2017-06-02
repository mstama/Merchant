using Merchant.Commands;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Merchant.Interfaces;

namespace Merchant
{
    public class CommandParser : ICommandParser
    {
        private static char[] _separator = new char[] { ' ' };

        public Command Parse(string value)
        {
            var words = value.Split(_separator, StringSplitOptions.RemoveEmptyEntries);
            value = value.ToUpperInvariant();
            //It is a query
            if (value.Contains("?"))
            {
                if(value.Contains("HOW MUCH IS "))
                {
                    string amount = string.Join(" ", words.Skip(3).Take(words.Length - 4));
                    return new MuchQueryCommand(amount);
                }
                if(value.Contains("HOW MANY CREDITS IS ")) {
                    string commodity = words[words.Length - 2];
                    string amount = string.Join(" ", words.Skip(4).Take(words.Length - 6));
                    return new ManyQueryCommand(commodity, amount);
                }
            }
            else //Its a Mapping-Rate
            {
                // Rate
                if (value.Contains("CREDITS")){
                    int credit = int.Parse(words[words.Length - 2]);
                    string commodity = words[words.Length - 4];
                    string amount = string.Join(" ",words.Take(words.Length - 4));
                    return new RateCommand(commodity, amount, credit);
                }
                else
                {
                    return new MapCommand(words[0], words[2]);
                }
            }
            return new UnknownCommand(value);
        }
    }
}
