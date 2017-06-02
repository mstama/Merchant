using System.Collections.Generic;

namespace Merchant.Converters
{
    public static class RomanNumberConverter
    {
        // Number mapping
        public static int NumberToInteger(string value)
        {
            var numbers = value.ToCharArray();
            var romans = new RomanNumber[numbers.Length];
            var subtracts = new HashSet<char>();
            RomanNumber previous = null;
            int repeat = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                var roman = RomanNumberFactory.Create(numbers[i]);
                // If number is not mapped
                if (roman == null|| subtracts.Contains(roman.Number)) return 0;

                // Rule 3 times only
                if (roman.Equals(previous))
                {
                    repeat++;
                    if (repeat > 3 || !roman.Repeat) return 0;
                }
                else
                {
                    repeat = 1;
                }

                // Rule Subtraction
                if (roman.PreviousSubtract(previous))
                {
                    previous.Subtract = true;
                    // Number that are used to subtract can not repeat
                    subtracts.Add(previous.Number);
                    subtracts.Add(roman.Number);
                }

                // invalid order
                if (i > 0)
                {
                    if (roman > previous && !previous.Subtract)
                    {
                        return 0;
                    }
                }

                romans[i] = roman;
                previous = roman;
            }
            int total = 0;
            // summ all
            foreach (var roman in romans)
            {
                if (roman.Subtract)
                {
                    total -= roman.Value;
                }
                else
                {
                    total += roman.Value;
                }
            }
            return total;
        }
    }
}