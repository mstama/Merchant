using System;

namespace Merchant.Exceptions
{
    /// <summary>
    /// Merchant application error
    /// </summary>
    public class MerchantException : Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Error description</param>
        public MerchantException(string message) : base(message) { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Error description</param>
        /// <param name="innerException">Inner exception</param>
        public MerchantException(string message, Exception innerException) : base(message, innerException) { }

        /// <summary>
        /// Constructor
        /// </summary>
        public MerchantException() : base("Merchant Error")
        {
        }
    }
}