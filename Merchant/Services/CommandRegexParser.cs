using Merchant.Interfaces;
using Merchant.Models;
using System;
using System.Text.RegularExpressions;

namespace Merchant.Services
{
    /// <summary>
    /// Parse the text commands using regex
    /// </summary>
    public class CommandRegexParser : ICommandParser
    {
        private const string _manyPattern = @"^ *how +many +(?<Target>\w+) +is +(?<AlienValue>.*\b) +(?<Commodity>\w+) *\? *$";
        private const string _mapPattern = @"^ *(?<From>\w+) +is +(?<To>\w+) *$";
        private const string _muchPattern = @"^ *how +much +is +(?<AlienValue>.*\b) *\? *$";
        private const string _ratePattern = @"^ *(?<AlienValue>.*) +(?<Commodity>\w+) +is +(?<TargetValue>\d+) +(?<Target>\w+) *$";
        private static readonly Regex _manyExpression = new Regex(_manyPattern, RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);
        private static readonly Regex _mapExpression = new Regex(_mapPattern, RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);
        private static readonly Regex _muchExpression = new Regex(_muchPattern, RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);
        private static readonly Regex _rateExpression = new Regex(_ratePattern, RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);

        /// <summary>
        /// Parse the text and returns a command
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public Command Parse(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) { return new NullCommand(); }

            if (_mapExpression.IsMatch(text))
            {
                var result = _mapExpression.Matches(text);
                return new MapCommand(result[0].Groups["From"].Value, result[0].Groups["To"].Value);
            }
            else if (_manyExpression.IsMatch(text))
            {
                var result = _manyExpression.Matches(text);
                if (!"Credits".Equals(result[0].Groups["Target"].Value, StringComparison.OrdinalIgnoreCase)) { return new UnknownCommand(text); }
                return new ManyQueryCommand(result[0].Groups["Commodity"].Value, result[0].Groups["AlienValue"].Value);
            }
            else if (_muchExpression.IsMatch(text))
            {
                var result = _muchExpression.Matches(text);
                return new MuchQueryCommand(result[0].Groups["AlienValue"].Value);
            }
            else if (_rateExpression.IsMatch(text))
            {
                var result = _rateExpression.Matches(text);
                if (!"Credits".Equals(result[0].Groups["Target"].Value, StringComparison.OrdinalIgnoreCase)) { return new UnknownCommand(text); }
                var targetValue = int.Parse(result[0].Groups["TargetValue"].Value);
                return new RateCommand(result[0].Groups["Commodity"].Value, result[0].Groups["AlienValue"].Value, targetValue);
            }
            return new UnknownCommand(text);
        }
    }
}