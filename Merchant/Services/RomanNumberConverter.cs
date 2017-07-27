// Copyright (c) 2017 Marcos Tamashiro. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

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

            if (previous == null) { throw new RomanDigitException("Empty or space roman number."); }

            return previous.SubTotal;
        }
    }
}