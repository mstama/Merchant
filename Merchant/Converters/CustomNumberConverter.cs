using System;
using System.Collections.Generic;
using System.Text;

namespace Merchant.Converters
{
    public class CustomNumberConverter
    {
        private Dictionary<string, string> _dict = new Dictionary<string, string>();
        private static char[] _separator = new char[]{' '};

        public string NumberToRoman(string value)
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

        public void AddMap(string fromValue, string toValue)
        {
            _dict.Add(fromValue, toValue);
        }
    }
}
