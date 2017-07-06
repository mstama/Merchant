using System;

namespace Merchant.Exceptions
{
    /// <summary>
    /// Error class for Rate calculator
    /// </summary>
    public class RateCalculatorException : MerchantException
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Error message</param>
        public RateCalculatorException(string message) : base(message) { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Error message</param>
        /// <param name="innerException">Inner exception</param>
        public RateCalculatorException(string message, Exception innerException) : base(message, innerException) { }

        /// <summary>
        /// Constructor
        /// </summary>
        public RateCalculatorException() : base("Rate Calculator Exception")
        {
        }
    }
}