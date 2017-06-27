using System;

namespace Merchant.Exceptions
{
    /// <summary>
    /// Error class for Roman Digits operatios
    /// </summary>
    public class RomanDigitException : MerchantException
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Error message</param>
        public RomanDigitException(string message) : base(message) { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Error message</param>
        /// <param name="innerException">Inner exception</param>
        public RomanDigitException(string message, Exception innerException) : base(message, innerException) { }
    }
}