using Merchant.Exceptions;
using Merchant.Interfaces;
using Merchant.Models;

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
            if (string.IsNullOrWhiteSpace(value)) { throw new RomanDigitException("Empty or space roman number."); }

            var numbers = value.ToCharArray();
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