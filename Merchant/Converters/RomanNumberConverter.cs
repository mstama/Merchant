using System.Collections.Generic;

namespace Merchant.Converters
{
    public static class RomanNumberConverter
    {
        // Number mapping
        private static Dictionary<char, int> _dict = new Dictionary<char, int>() { { 'I', 1 }, { 'V', 5 }, { 'X', 10 }, { 'L', 50 }, { 'C', 100 }, { 'D', 500 }, { 'M', 1000 } };
        private static Dictionary<char, char> _sub = new Dictionary<char, char>() { { 'V', 'I' }, { 'X', 'I' }, { 'L', 'X' }, { 'C', 'X' }, { 'D', 'C' }, { 'M', 'C' } };
        private static HashSet<char> _noRepeat = new HashSet<char>() { 'V', 'L', 'D' };

        public static int NumberToInteger(string value)
        {
            // Number parsing
            var numbers = value.ToCharArray();
            var usedToSub = new HashSet<char>();
            int total = 0;
            char prev = ' ';
            int count = 0;
            int prevSubtotal = int.MaxValue;
            for (int i = 0; i < numbers.Length; i++)
            {
                // If number is not mapped
                if (!_dict.ContainsKey(numbers[i])) return 0;
                // Used to subtract and appeared again.
                if (usedToSub.Contains(numbers[i])) return 0;
                // Map
                var subTotal = _dict[numbers[i]];
                // Rule 3 times only
                // Rule no repeat for V L D
                if (numbers[i] == prev)
                {
                    count++;
                    if (count > 3 || _noRepeat.Contains(numbers[i])) return 0;
                }
                else
                {
                    count = 1;
                    prev = numbers[i];
                }
                // Rule Subtraction
                if (i < numbers.Length - 1)
                {
                    // Look 1 ahead
                    var j = i + 1;
                    // If subtraction
                    if (_sub.TryGetValue(numbers[j], out char ahead))
                    {
                        // Negative
                        if (ahead == numbers[i])
                        {
                            subTotal *= -1;
                            usedToSub.Add(numbers[i]);
                        }
                    }
                }
                // Order is invalid
                if (subTotal > 0) 
                {
                    if (subTotal > prevSubtotal)
                    {
                        return 0;
                    }
                    else
                    {
                        prevSubtotal = subTotal;
                    }
                }

                total += subTotal;
            }
            return total;
        }
    }
}