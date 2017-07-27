// Copyright (c) 2017 Marcos Tamashiro. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;

namespace Merchant.Exceptions
{
    /// <summary>
    /// Error class for Roman Digits operations
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

        /// <summary>
        /// Constructor
        /// </summary>
        public RomanDigitException() : base("Roman Digit Exception")
        {
        }
    }
}