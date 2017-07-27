// Copyright (c) 2017 Marcos Tamashiro. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;

namespace Merchant.Extensions
{
    /// <summary>
    /// Extension methods for strings
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Contains that allows to specify the comparison method
        /// </summary>
        /// <param name="source"></param>
        /// <param name="check"></param>
        /// <param name="comp"></param>
        /// <returns></returns>
        public static bool Contains(this string source, string check, StringComparison comp)
        {
            return source.IndexOf(check, comp) >= 0;
        }
    }
}