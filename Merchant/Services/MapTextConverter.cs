using Merchant.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merchant.Services
{
    /// <summary>
    /// Provides text converted with the mapped entries
    /// </summary>
    public class MapTextConverter : IMapConverter<string, string>
    {
        private static readonly char[] _separator = { ' ' };
        private readonly Dictionary<string, string> _dict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Add a mapping
        /// </summary>
        /// <param name="from"></param>
        /// <param name="target"></param>
        public void AddMap(string from, string target)
        {
            _dict.Add(from, target);
        }

        /// <summary>
        /// Executes the conversion
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string Convert(string value)
        {
            var numbers = value.Split(_separator, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder output = new StringBuilder();
            foreach (var number in numbers)
            {
                if (_dict.TryGetValue(number, out string toValue))
                {
                    output.Append(toValue);
                }
                else
                {
                    output.Append(number);
                }
            }
            return output.ToString();
        }
    }
}