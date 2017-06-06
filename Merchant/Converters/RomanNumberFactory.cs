using System;
using System.Collections.Generic;

namespace Merchant.Converters
{
    /// <summary>
    /// Provides a factory
    /// </summary>
    public static class RomanNumberFactory
    {
        private readonly static Dictionary<char, Func<RomanNumber>> _dict = new Dictionary<char, Func<RomanNumber>>();

        static RomanNumberFactory()
        {
            _dict['I'] = () => new RomanNumberI();
            _dict['V'] = () => new RomanNumberV();
            _dict['X'] = () => new RomanNumberX();
            _dict['L'] = () => new RomanNumberL();
            _dict['C'] = () => new RomanNumberC();
            _dict['D'] = () => new RomanNumberD();
            _dict['M'] = () => new RomanNumberM();
        }

        /// <summary>
        /// Returns a new instance of RomanNumber's
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static RomanNumber Create(char number)
        {
            if (_dict.ContainsKey(number))
            {
                return _dict[number]();
            }
            else
            {
                return null;
            }
        }
    }
}