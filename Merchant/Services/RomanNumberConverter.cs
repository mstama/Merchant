using Merchant.Interfaces;
using Merchant.Models;
using Merchant.Exceptions;

namespace Merchant.Services
{
    /// <summary>
    /// Knows how to convert romans to integer
    /// </summary>
    public class RomanNumberConverter : IConverter<string, int>
    {
        /// <summary>
        /// Executes the conversion
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int Convert(string value)
        {
            var numbers = value.ToCharArray();
            var romans = new RomanDigit[numbers.Length];
            // List of romans that were used to subtract
            RomanDigit previous = null;
            for (int i = 0; i < numbers.Length; i++)
            {
                var roman = RomanDigitFactory.Create(numbers[i]);

                // If number is not mapped
                roman.SetPrevious(previous);
                previous = roman;
            }

            return previous.SubTotal;
        }
    }
}