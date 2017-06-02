using Merchant.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merchant.Converters
{
    /// <summary>
    /// Provides text converted with the mapped entries
    /// </summary>
    public class MapTextConverter : IMapConverter<string, string>
    {
        private Dictionary<string, string> _dict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        private readonly static char[] _separator = new char[]{' '};

        public string Convert(string value)
        {
            var numbers = value.Split(_separator, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder output = new StringBuilder();
            foreach(var number in numbers)
            {
                if(_dict.TryGetValue(number, out string toValue))
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

        public void AddMap(string from, string target)
        {
            _dict.Add(from, target);
        }
    }
}
