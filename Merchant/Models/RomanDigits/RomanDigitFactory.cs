// Copyright (c) 2017 Marcos Tamashiro. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Merchant.Exceptions;
using System;
using System.Collections.Generic;

namespace Merchant.Models
{
    /// <summary>
    /// Provides a factory
    /// </summary>
    public static class RomanDigitFactory
    {
        private readonly static Dictionary<char, Func<RomanDigit>> _dict = new Dictionary<char, Func<RomanDigit>>();

        static RomanDigitFactory()
        {
            _dict['I'] = () => new RomanDigitI();
            _dict['V'] = () => new RomanDigitV();
            _dict['X'] = () => new RomanDigitX();
            _dict['L'] = () => new RomanDigitL();
            _dict['C'] = () => new RomanDigitC();
            _dict['D'] = () => new RomanDigitD();
            _dict['M'] = () => new RomanDigitM();
        }

        /// <summary>
        /// Returns a new instance of RomanDigit's
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static RomanDigit Create(char number)
        {
            if (_dict.ContainsKey(number))
            {
                return _dict[number]();
            }
            else
            {
                throw new RomanDigitException("Unknown roman digit.");
            }
        }
    }
}