using System;
using System.Collections.Generic;
using System.Text;

namespace Merchant.Extensions
{
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