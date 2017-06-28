using Merchant.Models;
using Merchant.Interfaces;
using System;
using System.Linq;
using Merchant.Extensions;

namespace Merchant.Services
{
    /// <summary>
    /// Parse the text commands
    /// </summary>
    public class CommandParser : ICommandParser
    {
        private static char[] _separator = new char[] { ' ' };
        private StringComparison _comparer = StringComparison.OrdinalIgnoreCase;

        /// <summary>
        /// Parse the text and returns a command
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public Command Parse(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return new NullCommand();

            var words = text.Split(_separator, StringSplitOptions.RemoveEmptyEntries);
            //It is a query
            if (text.Contains("?", _comparer))
            {
                if (text.Contains("HOW MUCH IS ", _comparer))
                {
                    string amount = string.Join(" ", words.Skip(3).Take(words.Length - 4));
                    return new MuchQueryCommand(amount);
                }
                if (text.Contains("HOW MANY CREDITS IS ", _comparer))
                {
                    string commodity = words[words.Length - 2];
                    string amount = string.Join(" ", words.Skip(4).Take(words.Length - 6));
                    return new ManyQueryCommand(commodity, amount);
                }
            }
            else //Its a Mapping-Rate
            {
                // Rate
                if (text.Contains("CREDITS", _comparer))
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
            return new UnknownCommand(text);
        }
    }
}