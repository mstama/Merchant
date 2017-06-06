using Merchant.Interfaces;

namespace Merchant.Converters
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
            var romans = new RomanNumber[numbers.Length];
            // List of romans that were used to subtract
            RomanNumber previous = null;
            for (int i = 0; i < numbers.Length; i++)
            {
                var roman = RomanNumberFactory.Create(numbers[i]);

                // If number is not mapped
                if (roman == null) return 0;
                roman.AddPrevious(previous);
                previous = roman;
            }

            return previous.SubTotal;
        }
    }
}