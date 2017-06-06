using Merchant.Commands;
using Merchant.Interfaces;
using System;
using System.Linq;

namespace Merchant
{
    /// <summary>
    /// Parse the text commands
    /// </summary>
    public class CommandParser : ICommandParser
    {
        private static char[] _separator = new char[] { ' ' };

        /// <summary>
        /// Parse the text and returns a command
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Command Parse(string value)
        {
            var words = value.Split(_separator, StringSplitOptions.RemoveEmptyEntries);
            value = value.ToUpperInvariant();
            //It is a query
            if (value.Contains("?"))
            {
                if (value.Contains("HOW MUCH IS "))
                {
                    string amount = string.Join(" ", words.Skip(3).Take(words.Length - 4));
                    return new MuchQueryCommand(amount);
                }
                if (value.Contains("HOW MANY CREDITS IS "))
                {
                    string commodity = words[words.Length - 2];
                    string amount = string.Join(" ", words.Skip(4).Take(words.Length - 6));
                    return new ManyQueryCommand(commodity, amount);
                }
            }
            else //Its a Mapping-Rate
            {
                // Rate
                if (value.Contains("CREDITS"))
                {
                    int credit = int.Parse(words[words.Length - 2]);
                    string commodity = words[words.Length - 4];
                    string amount = string.Join(" ", words.Take(words.Length - 4));
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